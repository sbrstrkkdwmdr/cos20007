using SplashKitSDK;

namespace ShapeDrawer
{
    internal class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }
        public Drawing() : this(Color.White)
        {

        }
        public int ShapeCount
        {
            get
            {
                return _shapes.Count;
            }
        }
        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }
        public void RemoveShape(Shape shape)
        {
            _ = _shapes.Remove(shape);
        }
        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }
        }
        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape shape in _shapes)
            {
                shape.Selected = shape.IsAt(pt);
            }
        }
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> _result = new List<Shape>();
                foreach(Shape shape in _shapes)
                {
                    if(shape.Selected) _result.Add(shape);
                }
                return _result;
            }
        }
        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

    }
}
