using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Shape
    {
        public Color _colour { get; set; }
        public double _x { get; set; }
        public double _y { get; set; }
        public int _width { get; set; }
        public int _height { get; set; }
        private bool _selected;
        

        public Shape(int param)
        {
            _width = param;
            _height = param;
            _colour = Color.Azure;
            _x = 0.0f;
            _y = 0.0f;
        }

        public void Draw()
        {
            SplashKit.FillRectangle(_colour, _x, _y, _width, _height);
            if (_selected) DrawOutline();
        }

        public bool IsAt(Point2D pt)
        {
            if (pt.X >= _x & pt.X < _x + _width & pt.Y >= _y & pt.Y < _y + _height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }
        public void DrawOutline()
        {
            int _outlineThickness = 5 + 2;
            double x1 = _x;
            double y1 = _y;
            double x2 = _x + _width;
            double y2 = _y + _height;
            SplashKit.DrawLine(Color.Black, x1, y1, x2, y1);
            SplashKit.DrawLine(Color.Black, x2, y1, x2, y2);
            SplashKit.DrawLine(Color.Black, x2, y2, x1, y2);
            SplashKit.DrawLine(Color.Black, x1, y1, x1, y2);

        }

    }

}
