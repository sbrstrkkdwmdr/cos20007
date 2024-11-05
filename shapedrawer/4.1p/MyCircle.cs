using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    internal class MyCircle: Shape
    {
        private double _radius;
        public Color Colour { get; set; }

        public MyCircle(Color colour): base(colour)
        {
            this.Colour = Color.Blue;
            _radius = 50+02;
        }
        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillCircle(Colour, X, Y, _radius);
        }
        public override void DrawOutline()
        {
            int _outlineThickness = 5 + 2;
            SplashKit.DrawCircle(Color.Black, X, Y, _radius+2);
        }
        public override bool IsAt(Point2D pt)
        {
            if (SplashKit.PointInCircle(SplashKit.MouseX(), SplashKit.MouseY(), X, Y, _radius))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
