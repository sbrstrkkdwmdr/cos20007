using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        private Color _colour { get; set; }
        private double _x;
        private double _y;
        private bool _selected;

        public double X { get { return _x; } set { _x = value; } }
        public double Y {  get { return _y;} set { _y = value; } }
        public Color Colour { get { return _colour; } set { _colour = value; } }

        public Shape(Color colour)
        {
            _colour = colour;
            _x = 0.0f;
            _y = 0.0f;
            this.Colour = Color.Yellow;
        }

        public abstract void Draw();

        public abstract bool IsAt(Point2D pt);
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }
        public abstract void DrawOutline();

    }

}
