﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SharpGis.SharpGps;
using MapsLibrary;
using System.Runtime.InteropServices;

namespace MapperTool
{
    public partial class Form_MapperToolMain : Form
    {
        [DllImport("coredll")]
        extern static void SystemIdleTimerReset();

        protected MapperToolOptions options;
        string configfile;

        protected MapTS map;
        protected SparseImagesMap gmap;
        protected LayeredMap lmap;
        protected LayerPoints trackpoints;
        protected LayerPoints waypoints;
        protected int idx_layer_gmaps, idx_layer_osm;
        protected bool autocenter;
        GPSHandler GPS;
        bool started;
        StreamWriter swGPSLog;

        private GeoPoint gpspos;
        public GeoPoint GPSPosition
        {
            get
            {
                return gpspos;
            }
            set
            {
                gpspos = value;
                this.label_lat.Text = gpspos.dLat.ToString("F7");
                this.label_lon.Text = gpspos.dLon.ToString("F7");
                if (this.autocenter) 
                    mapcontrol.Center = map.mapsystem.CalcProjection(gpspos);
            }
        }

        public Form_MapperToolMain()
        {
            InitializeComponent();
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            configfile = path + "\\" + MapperToolResources.ConfigFile;
            options = (System.IO.File.Exists(configfile)) ?
                           MapperToolOptions.FromFile(configfile) : DefaultOptions();            

            this.pb_GPSActvity.Image = MapperToolResources.ImgGPS;

            this.lmap = new LayeredMap();
            // OSM
            this.map = new CachedMapTS(path + "\\tiles", new OSMTileMapSystem(), 20);
            idx_layer_osm = lmap.addLayerOnTop(this.map);
            // Google MAPS
            gmap = new SparseImagesMap(new SparseImagesMapSystem(), path + "/gmaps/");
            idx_layer_gmaps = lmap.addLayerOnTop(gmap);
            lmap.setVisibility(idx_layer_gmaps, false);
            // Tracciato GPS
            trackpoints = new LayerBufferedPoints(map.mapsystem);
            lmap.addLayerOnTop(trackpoints);
            // Waypoints
            waypoints = new LayerPoints(map.mapsystem);
            waypoints.SetDrawPointFunction(LayerPoints.DrawEmptySquare, new Pen(Color.Red));
            lmap.addLayerOnTop(waypoints);
            // Croce centrale
            lmap.addLayerOnTop(new LayerCrossCenter(20));


            mapcontrol.Map = lmap;
            this.mapcontrol.PrePaint += new MapControl.MapControlEventHandler(this.scarica_tiles);

            GeoPoint gp = new GeoPoint(44.1429, 12.2618);
            mapcontrol.Zoom = 12;
            mapcontrol.Center = map.mapsystem.CalcProjection(gp);

            this.GPS = new GPSHandler(this); //Initialize GPS handler
            GPS.TimeOut = 5; //Set timeout to 5 seconds
            GPS.NewGPSFix += new GPSHandler.NewGPSFixHandler(this.GPSEventHandler); //Hook up GPS data events to Y handler
            started = false;
        
        }

        /// <summary>
        /// Responds to sentence events from GPS receiver
        /// </summary>
        protected void GPSEventHandler(object sender, GPSHandler.GPSEventArgs e)
        {
            SystemIdleTimerReset();

            if (swGPSLog != null)
                swGPSLog.WriteLine(e.Sentence);

            switch (e.TypeOfEvent)
            {
                case GPSEventType.GPRMC:  //Recommended minimum specific GPS/Transit data
                    if (GPS.HasGPSFix) 
                    {
                        //lbRMCPosition.Text = GPS.GPRMC.Position.ToString("#.000000");
                        GeoPoint gp = new GeoPoint(GPS.GPRMC.Position.Latitude, GPS.GPRMC.Position.Longitude);
                        this.trackpoints.addPoint(map.mapsystem.CalcProjection(gp));
                        this.GPSPosition = gp;
                    }
                    else
                    {
                        // NOFIX
                    }
                    break;
            }
            if (e.TypeOfEvent != GPSEventType.TimeOut)
                this.pb_GPSActvity.Visible = !this.pb_GPSActvity.Visible;

        }

        private void mapcontrol_ZoomChanged(MapsLibrary.MapControl sender)
        {
            this.label_zoom.Text = sender.Zoom.ToString();
        }

        private void menuItem_zoomin_Click(object sender, EventArgs e)
        {
            this.mapcontrol.Zoom++;
        }

        private void menuItem_zoomout_Click(object sender, EventArgs e)
        {
            this.mapcontrol.Zoom--;
        }

        private void menuItem_map_osm_Click(object sender, EventArgs e)
        {
            if (!lmap.isVisible(idx_layer_osm))
            {
                lmap.setVisibility(idx_layer_osm, true);
                lmap.setVisibility(idx_layer_gmaps, false);
                mapcontrol.Invalidate();   
                this.menuItem_map_gmaps.Enabled = true;
                this.menuItem_map_osm.Enabled = false;
            }
        }

        private void menuItem_map_gmaps_Click(object sender, EventArgs e)
        {
            if (!lmap.isVisible(idx_layer_gmaps))
            {
                lmap.setVisibility(idx_layer_osm, false);
                lmap.setVisibility(idx_layer_gmaps, true);
                mapcontrol.Invalidate();
                this.menuItem_map_gmaps.Enabled = false;
                this.menuItem_map_osm.Enabled = true;
            }
        }

        private void menuItem_loadtrack_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string file = path + "\\log.nmea.txt";
            int count = 0;

            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (System.IO.StreamReader sr = new System.IO.StreamReader(file))
                {
                    String line;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.StartsWith("$GPRMC"))
                        {
                            SharpGis.SharpGps.NMEA.GPRMC gpmrc = new SharpGis.SharpGps.NMEA.GPRMC(line);
                            GeoPoint gp = new GeoPoint(gpmrc.Position.Latitude, gpmrc.Position.Longitude);
                            this.trackpoints.addPoint(this.map.mapsystem.CalcProjection(gp));
                            count++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }
            System.Windows.Forms.Cursor.Current = Cursors.Default;
            mapcontrol.Invalidate();
        }

        private void menuItem_followGPS_Click(object sender, EventArgs e)
        {
            autocenter = !autocenter;
            this.menuItem_followGPS.Text = autocenter ? "Don't follow GPS" : "Follow GPS";
        }

        private void menuItem_gpsactivity_Click(object sender, EventArgs e)
        {
            if (!this.started)
            {
                if (options.GPS.Simulation && File.Exists(options.GPS.SimulationFile))
                {
                    GPS.EnableEmulate(options.GPS.SimulationFile);
                    // DEBUG
                    FileInfo logfile = new FileInfo(options.GPS.LogsDir + "\\gpslog_" + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + ".txt");
                    swGPSLog = new StreamWriter(logfile.FullName);
                    swGPSLog.AutoFlush = true;
                    // FINE DEBUG
                }
                else
                {
                    GPS.Emulate = false;
                    FileInfo logfile = new FileInfo(options.GPS.LogsDir + "\\gpslog_" + DateTime.Now.ToString("yyyy-mm-dd_HHmmss") + ".txt");
                    if (!logfile.Directory.Exists)
                        logfile.Directory.Create();
                    swGPSLog = new StreamWriter(logfile.FullName);
                    swGPSLog.AutoFlush = true;
                }
                GPS.Start(options.GPS.PortName, options.GPS.PortSpeed);
                this.started = true;
                this.menuItem_gpsactivity.Text = "Stop GPS";
            }
            else
            {
                GPS.Stop();
                if (swGPSLog != null)
                {
                    swGPSLog.Close();
                    swGPSLog.Dispose();
                    swGPSLog = null;
                }
                this.started = false;
                this.menuItem_gpsactivity.Text = "Start GPS";
            }
        }

        private void menuItem_downloadmaps_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

            PxCoordinates c1, c2;
            //c1 = map.mapsystem.TileCooToPx(this.pb_Centered.tc);
            c1 = map.mapsystem.PointToPx(mapcontrol.Center, mapcontrol.Zoom);
            c1.xpx -= this.mapcontrol.Size.Width / 2;
            c1.ypx -= this.mapcontrol.Size.Height / 2;
            c2 = c1;
            c2.xpx += this.mapcontrol.Size.Width;
            c2.ypx += this.mapcontrol.Size.Height;
            ProjectedGeoArea area = new ProjectedGeoArea(map.mapsystem.PxToPoint(c1, mapcontrol.Zoom), map.mapsystem.PxToPoint(c2, mapcontrol.Zoom));
            for (uint i = 1; i <= options.Maps.OSM.DownloadDepth; i++)
                map.downloadArea(area, mapcontrol.Zoom + i, false);

            // scarica le mappe di google maps
            gmap.downloadAt(mapcontrol.Center, mapcontrol.Zoom, false);
            gmap.downloadAt(mapcontrol.Center, mapcontrol.Zoom + 1, false);
            Int32 delta = gmap.mapsystem.PxToPoint(new PxCoordinates(256, 0), mapcontrol.Zoom + 2).nLon;  // dipende dalla dimensione massima di un'immagine di mappa
            ProjectedGeoPoint p = mapcontrol.Center;
            gmap.downloadAt(new ProjectedGeoPoint(p.nLat - delta, p.nLon - delta), mapcontrol.Zoom + 2, false);
            gmap.downloadAt(new ProjectedGeoPoint(p.nLat - delta, p.nLon + delta), mapcontrol.Zoom + 2, false);
            gmap.downloadAt(new ProjectedGeoPoint(p.nLat + delta, p.nLon - delta), mapcontrol.Zoom + 2, false);
            gmap.downloadAt(new ProjectedGeoPoint(p.nLat + delta, p.nLon + delta), mapcontrol.Zoom + 2, false);

            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }

        private void scarica_tiles(MapControl sender)
        {
            if (lmap.isVisible(idx_layer_osm)) {
                this.map.downloadAt(sender.Center, sender.Zoom, false);
            }
        }

        private void menuItem_config_Click(object sender, EventArgs e)
        {
            using (FormOptions opt = new FormOptions())
            {
                opt.data = this.options;
                opt.ShowDialog();
                options = opt.data;
                options.SaveToFile(this.configfile);
            }
        }

        private static MapperToolOptions DefaultOptions()
        {
            string programpath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            MapperToolOptions opt = new MapperToolOptions();
            opt.GPS.PortName = "COM1";
            opt.GPS.PortSpeed = 9600;
            opt.GPS.Simulation = false;
            opt.GPS.SimulationFile = "";
            opt.GPS.LogsDir = programpath + "\\gpslogs";
            opt.Maps.OSM.OSMTileServer = "http://tile.openstreetmap.org/";
            opt.Maps.OSM.TileCachePath = programpath + "\\tiles";
            opt.Maps.OSM.DownloadDepth = 3;
            opt.Maps.OSM.AutoDownload = true;
            opt.Maps.GMaps.CachePath = programpath + "\\gmaps";
            return opt;
        }

        private void menuItem_waypoint_Click(object sender, EventArgs e)
        {
            create_waypoint();
        }

        private void create_waypoint()
        {
            if (this.started && swGPSLog != null ) {
                double lat = gpspos.dLat,
                       lon = gpspos.dLon;
                string NordSud =  (lat > 0) ? ",N," : ",S,",
                       EstOvest = (lon > 0) ? ",E," : ",W,";
                lat = Math.Abs(lat);
                lon = Math.Abs(lon);
                int latdeg = (int)Math.Floor(lat),
                    londeg = (int)Math.Floor(lon);
                lat = (lat - latdeg) * 60;
                lon = (lon - londeg) * 60;

                string sentence = "$GPWPL," + latdeg.ToString("D2") + lat.ToString("00.#######") + NordSud
                                + londeg.ToString("D3") + lon.ToString("00.#######") + EstOvest 
                                + "WPT " + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + '*';
                
                swGPSLog.WriteLine(sentence + getNMEAChecksum(sentence));
                waypoints.addPoint(map.mapsystem.CalcProjection(gpspos));
            }
        }

        // Calculates the checksum for a sentence
        private static string getNMEAChecksum(string sentence)
        {
            //Start with first Item
            int checksum = Convert.ToByte(sentence[sentence.IndexOf('$') + 1]);
            // Loop through all chars to get a checksum
            for (int i = sentence.IndexOf('$') + 2; i < sentence.IndexOf('*'); i++)
            {
                // No. XOR the checksum with this character's value
                checksum ^= Convert.ToByte(sentence[i]);
            }
            // Return the checksum formatted as a two-character hexadecimal
            return checksum.ToString("X2");
        }

        private void Form_MapperToolMain_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
                create_waypoint();
            }

        }

        private void menuItem_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Close application. Are you sure?", "", MessageBoxButtons.YesNo,MessageBoxIcon.None,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                Application.Exit();

        }


    }
}