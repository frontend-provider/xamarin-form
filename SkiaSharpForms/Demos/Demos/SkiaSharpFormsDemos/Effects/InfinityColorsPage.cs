﻿using System;
using System.Diagnostics;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Effects
{
	public class InfinityColorsPage : ContentPage
	{
        const int STROKE_WIDTH = 50;

        SKCanvasView canvasView;
        SKPath infinityPath;
        bool isAnimating;
        float offset;
        Stopwatch stopwatch = new Stopwatch();

        public InfinityColorsPage ()
		{
            infinityPath = new SKPath();
            infinityPath.MoveTo(0, 0);                                  // Center
            infinityPath.CubicTo(  50,  -50,   95, -100,  150, -100);   // To top of right loop
            infinityPath.CubicTo( 205, -100,  250,  -55,  250,    0);   // To far right of right loop
            infinityPath.CubicTo( 250,   55,  205,  100,  150,  100);   // To bottom of right loop
            infinityPath.CubicTo(  95,  100,   50,   50,    0,    0);   // Back to center  
            infinityPath.CubicTo( -50,  -50,  -95, -100, -150, -100);   // To top of left loop
            infinityPath.CubicTo(-205, -100, -250,  -55, -250,    0);   // To far left of left loop
            infinityPath.CubicTo(-250,   55, -205,  100, -150,  100);   // To bottom of left loop
            infinityPath.CubicTo( -95,  100, - 50,   50,    0,    0);   // Back to center
            infinityPath.Close();

            canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            isAnimating = true;
            stopwatch.Start();
            Device.StartTimer(TimeSpan.FromMilliseconds(16), OnTimerTick);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            stopwatch.Stop();
            isAnimating = false;
        }

        bool OnTimerTick()
        {
            const int duration = 20000;
            offset = 550f * (stopwatch.ElapsedMilliseconds % duration) / duration;
            canvasView.InvalidateSurface();

            return isAnimating;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKRect pathBounds = infinityPath.Bounds;

            // Set transforms to shift path to center and scale to canvas size
            canvas.Translate(info.Width / 2, info.Height / 2);
            canvas.Scale(0.95f * 
                Math.Min(info.Width / (pathBounds.Width + STROKE_WIDTH),
                         info.Height / (pathBounds.Height + STROKE_WIDTH)));

            // Define colors for gradient
            SKColor[] colors = new SKColor[8];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = SKColor.FromHsl(i * 360f / 7, 100, 50);
            }

            using (SKPaint paint = new SKPaint())
            {
                paint.Style = SKPaintStyle.Stroke;
                paint.StrokeWidth = STROKE_WIDTH;
                paint.Shader = SKShader.CreateLinearGradient(
                                    new SKPoint(pathBounds.Left, pathBounds.Top),
                                    new SKPoint(pathBounds.Right, pathBounds.Bottom),
                                    colors,
                                    null,
                                    SKShaderTileMode.Repeat,
                                    SKMatrix.MakeTranslation(offset, 0));

                canvas.DrawPath(infinityPath, paint);
            }
        }
    }
}
