﻿using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Bitmaps
{
    public class LatticeDisplayPage : ContentPage
    {
        public LatticeDisplayPage()
        {
            Title = "Lattice Display";

            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKLattice lattice = new SKLattice();
            lattice.XDivs = new int[] { 100, 200, 400 };
            lattice.YDivs = new int[] { 100, 300, 400 };

            int count = (lattice.XDivs.Length + 1) * (lattice.YDivs.Length + 1);
            lattice.Flags = new SKLatticeFlags[count];

            for (int i = 0; i < count; i++)
            {
                lattice.Flags[i] = SKLatticeFlags.Default;
            }

            canvas.DrawBitmapLattice(NinePatchDisplayPage.FiveByFiveBitmap, lattice, info.Rect);
        }
    }
}