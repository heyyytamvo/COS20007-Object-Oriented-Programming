using System;
using SplashKitSDK;
namespace ShapeDrawing
{
	public abstract class Shape
	{
		private Color _color;
		private bool _selected;
		private Point2D _location;


		public Shape()
		{
			_color = Color.Green;
			_location.X = 0;
			_location.Y = 0;
			_selected = false;
		}

		//properties for x-coordinate
		public double location_x
		{
			get
			{
				return _location.X;
			}
			set
			{
				_location.X = value;
			}
		}

		//properties for y-coordinate
		public double location_y
		{
			get
			{
				return _location.Y;
			}
			set
			{
				_location.Y = value;
			}
		}

		//properties for color
		public Color get_color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
			}
		}
		//properties for selected
		public bool Selected
        {
            get
            {
				return _selected;
            }
            set
            {
				_selected = value;
            }
        }

		//abtract method for draw
		public abstract void Draw();

		//abtract method for draw outline
		public abstract void DrawOutline();

		//abtract method for isAt
		public abstract bool isAt(Point2D point);
	}
}

