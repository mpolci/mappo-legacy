﻿/*******************************************************************************
 *  Mappo! - A tool for gps mapping.
 *  Copyright (C) 2008  Marco Polci
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see http://www.gnu.org/licenses/gpl.html.
 * 
 ******************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;

namespace MapsLibrary
{
    using TileIdxType = Int32;

    public class ReadAheadCachedTilesMap : CachedTilesMap, IDisposable
    {
        private uint oldZoom;
        private ProjectedGeoPoint oldCenter;
        private PxCoordinates raareasize;
        private bool threadrun;
        private Thread thrReadAhead;
        private AutoResetEvent jobEvent;
        private object joblock;
        private ProjectedGeoArea jobArea;
        private uint jobZoom;


        public ReadAheadCachedTilesMap(string tileCachePath, TileMapSystem ms, uint cachelen, Size ReadAheadAreaSize) :
            base(tileCachePath, ms, cachelen)
        {
            raareasize = new PxCoordinates(ReadAheadAreaSize.Width, ReadAheadAreaSize.Height);
            oldZoom = 0;
            oldCenter = new ProjectedGeoPoint(0, 0);
            joblock = new object();
            jobEvent = new AutoResetEvent(false);
            threadrun = true;
            thrReadAhead = new Thread(new ThreadStart(this.RedAheadThreadProc));
            thrReadAhead.Priority = ThreadPriority.BelowNormal;
            thrReadAhead.Name = "Tiles predownloader";
            thrReadAhead.Start();
        }

        public override void drawImageMapAt(MapsLibrary.ProjectedGeoPoint map_center, uint zoom, MapsLibrary.ProjectedGeoArea area, System.Drawing.Graphics g, System.Drawing.Point delta)
        {
            if (zoom == oldZoom && map_center != oldCenter)
            {
                PxCoordinates pxCenter = mMapsys.PointToPx(map_center, zoom),
                              shift = pxCenter - mMapsys.PointToPx(oldCenter, zoom),
                              raC1 = pxCenter + shift * 4 - raareasize / 2,
                              raC2 = raC1 + raareasize;
                ProjectedGeoArea raArea = new ProjectedGeoArea(mMapsys.PxToPoint(raC1, zoom), mMapsys.PxToPoint(raC2, zoom));
                lock (joblock)
                {
                    jobArea = raArea;
                    jobZoom = zoom;
                    jobEvent.Set();
                }
            }
            oldZoom = zoom; 
            oldCenter = map_center;                
            base.drawImageMapAt(map_center, zoom, area, g, delta);
        }

        public void RedAheadThreadProc()
        {
            while (true)
            {
                jobEvent.WaitOne();
                if (!threadrun) return;
                ProjectedGeoArea area;
                uint zoom;
                lock (joblock)
                {
                    area = jobArea;
                    zoom = jobZoom;
                }
                TileNum tn1 = mMapsys.PointToTileNum(area.pMin, zoom),
                        tn2 = mMapsys.PointToTileNum(area.pMax, zoom);
                TileIdxType x1 = Math.Min(tn1.X, tn2.X),
                            x2 = Math.Max(tn1.X, tn2.X),
                            y1 = Math.Min(tn1.Y, tn2.Y),
                            y2 = Math.Max(tn1.Y, tn2.Y);
                TileNum i = new TileNum();
                i.uZoom = zoom;
                for (i.X = x1; i.X <= x2; i.X++)
                    for (i.Y = y1; i.Y <= y2; i.Y++)
                        getImageTile(i);
            }
        }


        #region IDisposable Members

        public override void Dispose()
        {
            threadrun = false;
            jobEvent.Set();
            thrReadAhead.Join();
            base.Dispose();
        }

        #endregion
    }
}
