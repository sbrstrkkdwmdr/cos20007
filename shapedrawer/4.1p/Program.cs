using SplashKitSDK;
using System;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line,
        }
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing(Color.Random());
            ShapeKind kindToAdd = ShapeKind.Circle;
            int _lineCounter = 2; //last digit of student id is "2"
            int _numberOfLines = 0;
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape _thisShape;
                    
                    switch (kindToAdd)
                    {
                        case ShapeKind.Circle:
                            _thisShape = new MyCircle(Color.Random());
                            break;
                        case ShapeKind.Line:
                            _thisShape = new MyLine(Color.Random());
                            _numberOfLines++;
                            break;
                        default:
                            _thisShape = new MyRectangle(Color.Random());
                            break;
                    }
                    _thisShape.X = SplashKit.MouseX();
                    _thisShape.Y = SplashKit.MouseY();
                    // limit lines to be under last digit of student id
                    if(!(kindToAdd == ShapeKind.Line && _numberOfLines > _lineCounter))
                    {
                        myDrawing.AddShape(_thisShape);
                    } else
                    {
                        _numberOfLines = 2;
                    }
                }
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = Color.Random();
                }
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapesAt(SplashKit.MousePosition());
                }
                if (SplashKit.KeyTyped(KeyCode.BackspaceKey) || SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                    foreach (Shape shape in myDrawing.SelectedShapes)
                    {
                        myDrawing.RemoveShape(shape);
                        // if its a line
                        // _numberOfLines--;
                        string _tempType = $"{shape.GetType()}";
                        if (_tempType == "ShapeDrawer.MyLine")
                        {
                            _numberOfLines--;
                            if(_numberOfLines <= 0)
                            {
                                _numberOfLines = 0;
                            }
                        }
                    }
                }
                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                myDrawing.Draw();


                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}
