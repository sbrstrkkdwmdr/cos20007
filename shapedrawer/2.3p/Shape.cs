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
			}

			public bool IsAt(Point2D pt)
			{
				if (pt.X >= _x & pt.X < _x + _width & pt.Y >= _y & pt.Y < _y + _height)
				{
					return true;
				} else
				{
					return false;
				}
			}
	}

}
