using System;
using SplashKitSDK;
using System.Collections.Generic;
namespace ShapeDrawing
{
	public class MyLine : Shape
	{
		private float _endX;
		private float _endY;
		
		//constructor
		public MyLine(Color color, float startX, float startY, float endX, float endY) 
		{
			_endX = endX;
			_endY = endY;
			location_x = startX;
			location_y = startY;
		}



		//properties
		public float endX
        {
            get
            {
				return _endX;
            }
        }

		public float endY
        {
            get
            {
				return _endY;
            }
        }
		///////////////////////
		//method for drawing
		public override void Draw()
		{
			if (Selected)
				DrawOutline();
			SplashKit.DrawLine(Color.Green, location_x, location_y, endX, endY);
		}
		
		//method for drawing selected shape
		public override void DrawOutline()
		{
			Circle firstCircle = SplashKit.CircleAt(location_x, location_y, 5);
			Circle secondCircle = SplashKit.CircleAt(endX, endY, 5);
			SplashKit.DrawCircle(Color.Black, firstCircle);
			SplashKit.DrawCircle(Color.Black, secondCircle);
		}

		//method for isAt method of the rectangle
		public override bool isAt(Point2D point)
		{
			return SplashKit.PointOnLine(point, SplashKit.LineFrom(location_x, location_y, endX, endY));
		}
	}
}

