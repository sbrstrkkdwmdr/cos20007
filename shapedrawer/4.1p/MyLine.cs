using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyLine : Shape 
    {
        public MyLine(Color colour) : base(colour)
        {
            this.Colour = Color.Red;
        }
        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.DrawLine(Colour, X, Y, X + 50, Y + 50);
        }
        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, 10);
            SplashKit.DrawCircle(Color.Black, X+50, Y+50, 10);
        }
        public override bool IsAt(Point2D pt)
        {
            if (SplashKit.PointOnLine(SplashKit.MousePosition(), new Line() { StartPoint = new Point2D() { X = X, Y = Y }, EndPoint = new Point2D() { X = X+50, Y = Y+50} }))
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
