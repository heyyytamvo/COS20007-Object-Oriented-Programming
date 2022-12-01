using System;
using SplashKitSDK;
namespace ShapeDrawing
{
	public class MyCircle : Shape
	{
		private int _radius = 50;



		//constructor
		public MyCircle(double x_coor, double y_coor)
		{
			location_x = x_coor;
			location_y = y_coor;
			get_color = Color.Green;
		}

		public MyCircle() : this(0, 0) { }
		public int Radius
        {
            get
            {
				return _radius;
            }
            set
            {
				_radius = value;
            }
        }
		//properties return the position of the circle
		public Point2D Posi
        {
            get
            {
				Point2D posi;
				posi.X = location_x;
				posi.Y = location_y;
				return posi;
            }
        }

		//method for drawing
		public override void Draw()
		{
			if (Selected)
			{
				DrawOutline();
			}
			SplashKit.FillCircle(get_color, location_x, location_y, _radius);
		}

		//method for drawing selected shape
		public override void DrawOutline()
		{
			SplashKit.FillCircle(Color.Black, location_x, location_y, _radius + 3);
		}

		//method for isAt method of the circle
		public override bool isAt(Point2D point)
		{
			Point2D virtual_point = new Point2D();
			virtual_point.X = location_x;
			virtual_point.Y = location_y;
			Circle circle = SplashKit.CircleAt(virtual_point, _radius);
			return SplashKit.PointInCircle(point, circle);
		}
	}
}


