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
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Runtime.InteropServices;


namespace MapperTools.Pollicino
{
    public partial class BlinkingControlNotifier : Component, IWorkNotifier
    {
        public BlinkingControlNotifier()
        {
            InitializeComponent();

            bstart = new AsyncDelegate(this.BlinkStart);
            bstop = new AsyncDelegate(this.BlinkStop);
            lockWorksCount = new object();
        }

        public BlinkingControlNotifier(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            bstart = new AsyncDelegate(this.BlinkStart);
            bstop = new AsyncDelegate(this.BlinkStop);
            
        }

        System.Windows.Forms.Control control;
        delegate void AsyncDelegate();
        private AsyncDelegate bstart, bstop;
        private bool _visibleonstop;

        private object lockWorksCount = new object();
        private int workscount = 0;

        public System.Windows.Forms.Control BlinkingControl 
        {
            get { return control; }
            set { 
                control = value; 
                control.Visible = Blink ? true : _visibleonstop; 
            }
        }

        public int BlinkingInterval
        {
            get
            {
                return timerBlinking.Interval;
            }
            set
            {
                timerBlinking.Interval = value;
            }
        }

        public bool VisibleOnStop
        {
            get
            {
                return _visibleonstop;
            }
            set
            {
                _visibleonstop = value;
                if (!Blink)
                    control.Visible = value;
            }
        }

        public bool Blink
        {
            get
            {
                return timerBlinking.Enabled;
            }
            set
            {
                if (timerBlinking.Enabled != value) {
                    timerBlinking.Enabled = value;
                    control.Visible = value ? true : _visibleonstop;
                }
            }
        }

        #region IWorkNotifier methods
        /// <summary>
        /// Invocato per notificare l'inizio di un lavoro
        /// </summary>
        /// <remarks>Questo metodo può essere invocato da un thread diverso da quello che ha creato il controllo di notifica</remarks>
        public void WorkBegin()
        {
            // dato che il metodo è possibile che sia invocato da un thread diverso da quello del controllo,
            // verifico che il controllo non sia disposed. Forse sarebbe meglio non fare il controllo e lasciare
            // che si propaghi l'eccezione che si genererebbe.
            if (control == null || control.IsDisposed) return;
            control.BeginInvoke(bstart);
        }

        /// <summary>
        /// Invocato per notificare la fine di un lavoro
        /// </summary>
        /// <remarks>Questo metodo può essere invocato da un thread diverso da quello che ha creato il controllo di notifica</remarks>
        public void WorkEnd()
        {
            if (control == null || control.IsDisposed) return;
            control.BeginInvoke(bstop);
        }
        #endregion

        private void BlinkStart()
        {
            lock (lockWorksCount)
            {
                if (workscount == 0)
                    Blink = true;
                workscount++;
            }
        }
        private void BlinkStop()
        {
            lock (lockWorksCount)
            {
                System.Diagnostics.Trace.Assert(workscount > 0, "job_end(): workscount is not greather than 0");
                workscount--;
                if (workscount == 0)
                    Blink = false;
            }
        }

        private void timerBlinking_Tick(object sender, EventArgs e)
        {
            //if (control == null || control.IsDisposed) return;
            control.Visible = !control.Visible;
            PlatformSpecificCode.SystemIdleTimerReset();
        }
     }
}
