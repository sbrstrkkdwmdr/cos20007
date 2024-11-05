using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        public int _width;
        public int _height;

        public int Width { get { return _width; } set { _width = (int)value; } }
        public int Height { get { return _height; } set { _height = (int)value; } }

            public MyRectangle(Color colour) : base(colour)
            {
                _width = 100+02;
                _height = 100+02;
                this.Colour = Color.Green;
            }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillRectangle(Colour, X, Y, _width, _height);
        }
        public override void DrawOutline()
        {
            double x1 = X;
            double y1 = Y;
            double x2 = X + _width;
            double y2 = Y + _height;
            SplashKit.DrawRectangle(Color.Black, X-1, Y-1, _width+2, _height+2);
        }
        public override bool IsAt(Point2D pt)
        {
            if (pt.X >= X & pt.X < X + _width & pt.Y >= Y & pt.Y < Y + _height)
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
