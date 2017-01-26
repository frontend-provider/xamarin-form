﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos
{
    public partial class PulsatingEllipsePage : ContentPage
    {
        Stopwatch stopwatch = new Stopwatch();
        float scale;            // ranges from 0 to 1 to 0

        public PulsatingEllipsePage()
        {
            InitializeComponent();

            AnimationLoop();
        }

        async void AnimationLoop()
        {
            stopwatch.Start();

            while (true)
            {
                double cycleTime = slider.Value;
                double t = stopwatch.Elapsed.TotalSeconds % cycleTime / cycleTime;
                scale = (1 + (float)Math.Sin(2 * Math.PI * t)) / 2;
                canvasView.InvalidateSurface();
                await Task.Delay(TimeSpan.FromSeconds(1.0 / 30));
            }
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            float maxRadius = 0.75f * Math.Min(info.Width, info.Height) / 2;
            float minRadius = 0.25f * maxRadius;

            float xRadius = minRadius * scale + maxRadius * (1 - scale);
            float yRadius = maxRadius * scale + minRadius * (1 - scale);

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Blue,
                StrokeWidth = 50
            };
            canvas.DrawOval(info.Width / 2, info.Height / 2, xRadius, yRadius, paint);

            paint.Style = SKPaintStyle.Fill;
            paint.Color = SKColors.SkyBlue;
            canvas.DrawOval(info.Width / 2, info.Height / 2, xRadius, yRadius, paint);
        }

    }
}
