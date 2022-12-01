using System;
using SplashKitSDK;
using System.Collections.Generic;
using System.Linq;
namespace ShapeDrawer
{
	public class Shape
	{
		private Color _color;
		private bool _selected;
		private int _width, _height;
		private Point2D _location;

		
		public Shape()
		{
			_color = Color.Green;
			_location.X = 0;
			_location.Y = 0;
			_width = 100;
			_height = 100;
			_selected = false;
		}
		

		//properties for selected
		public bool selected{
			get {
				return _selected;
			}
			set{
				_selected = value;
			}
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
		public Color color
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

		//properties for width
		public int width
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
		//properties for height
		public int height
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


		//drawOutline method to help user determine which shape is selected
        void drawOutline(){
				SplashKit.FillRectangle(Color.Black, _location.X - 2, _location.Y - 2, _width + 4, _height + 4);
        }
		//draw method
		public void Draw()
        {
			if (_selected)
			{
				drawOutline();
			}
			SplashKit.FillRectangle(_color, _location.X, _location.Y, _width, _height);
			
        }

		public bool IsAt(Point2D point)
        {
			if ((point.X > _location.X && point.X < (_location.X + _width)) && (point.Y > _location.Y && point.Y < (_location.Y + _height)))
            {
				return true;
            }
			return false;
        }


	}
}

