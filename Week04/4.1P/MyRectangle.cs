using System;
using SplashKitSDK;
namespace ShapeDrawing
{
	public class MyRectangle : Shape
	{
		private int _width, _height;
		
		//constructor
		public MyRectangle(double x_coor, double y_coor, int width, int height) 
		{
			_width = 100;
			_height = 100;
			location_x = x_coor;
			location_y = y_coor;
			get_color = Color.Green;
		}

		public MyRectangle() : this(0, 0, 100, 100) { }

		//properties for rectangle width
		public int rectangle_width
        {
            get
            {
				return _width;
            }
            set
            {
				_width = value;
            }
        }

		//properties for rectangle height
		public int rectangle_height
		{
			get
			{
				return _height;
			}
			set
			{
				_height = value;
			}
		}

        //method for drawing
        public override void Draw()
        {
			if (Selected)
			{
				DrawOutline();
			}
			SplashKit.FillRectangle(get_color, location_x, location_y, _width, _height);
		}

        //method for drawing selected shape
        public override void DrawOutline()
        {
			SplashKit.FillRectangle(Color.Black, location_x - 2, location_y - 2, _width + 4, _height + 4);
		}

        //method for isAt method of the rectangle
        public override bool isAt(Point2D point)
        {
			if ((point.X > location_x && point.X < (location_x + _width)) && (point.Y > location_y && point.Y < (location_y + _height)))
			{
				return true;
			}
			return false;
		}
    }
}

