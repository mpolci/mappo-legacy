﻿using System;
using System.Text;
using System.Runtime.InteropServices;

namespace MapsLibrary
{
    class Tools
    {

        public static TEXTMETRICS GetTextMetrics(System.Drawing.Font font)
        {
            IntPtr hDC = GetDC(IntPtr.Zero); //Screen DC
            IntPtr hFont = font.ToHfont();
            IntPtr hObjOld = SelectObject(hDC, hFont);
            TEXTMETRICS tm = new TEXTMETRICS();
            GetTextMetrics(hDC, ref tm);
            SelectObject(hDC, hObjOld);
            DeleteObject(hFont);
            ReleaseDC(IntPtr.Zero, hDC);
            return tm;
        }
#if PocketPC || Smartphone || WindowsCE
        const string dll_dc="coredll";
        const string dll_obj="coredll";
#else
        const string dll_dc="user32";
        const string dll_obj = "gdi32";
#endif

        [DllImport(dll_dc)]
        private extern static IntPtr GetDC(IntPtr hWnd);

        [DllImport(dll_dc)]
        private extern static IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport(dll_obj)]
        private extern static IntPtr SelectObject(IntPtr hDC, IntPtr hObj);

        [DllImport(dll_obj)]
        private extern static IntPtr DeleteObject(IntPtr hObject);

        [DllImport(dll_obj, CharSet = CharSet.Unicode)]
        private extern static int GetTextMetrics(IntPtr hDC, ref TEXTMETRICS tm);
//#else
//        public static TEXTMETRICS GetTextMetrics(System.Drawing.Font font)
//        {
//            TEXTMETRICS tm = new TEXTMETRICS();
//            return tm;
//        }
//#endif
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct TEXTMETRICS
    {
        public int tmHeight;
        public int tmAscent;
        public int tmDescent;
        public int tmInternalLeading;
        public int tmExternalLeading;
        public int tmAveCharWidth;
        public int tmMaxCharWidth;
        public int tmWeight;
        public int tmOverhang;
        public int tmDigitizedAspectX;
        public int tmDigitizedAspectY;
        public byte tmFirstChar;
        public byte tmLastChar;
        public byte tmDefaultChar;
        public byte tmBreakChar;
        public byte tmItalic;
        public byte tmUnderlined;
        public byte tmStruckOut;
        public byte tmPitchAndFamily;
        public byte tmCharSet;
    } 
}
