using System;
using SplashKitSDK;
using System.Collections.Generic;
using System.Linq;

namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        //this is the contructor
        public Drawing(Color background){
            _shapes = new List<Shape>();
            _background = background;
        }
        
        //additional contructor with no parameter
        public Drawing(): this (Color.White){

        }

        ///add shape method
        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        /// drawing method 
        /// also, This will tell SplashKit to clear the screen to the background 
        /// color, and then loop over each shape and tell it to draw itself.

        public void Draw(){
            SplashKit.ClearScreen(_background);
            //for each shape, tell it to draw itself 
            foreach(Shape shape in _shapes){    
                shape.Draw();           
            }
            /*
            Console.WriteLine("Current shapes are: ");
            foreach (Shape shape in _shapes)
            {
                Console.WriteLine("shape at {0} {1}", shape.location_x, shape.location_y);
            }
            */
        }

        ///
        /// SelectShapesAt method to the Drawing class. 
        /// This will be called when the user wants to select shapes 
        /// they have already added to the Drawing
        public void SelectShapesAt(Point2D mouse){
            foreach (Shape shape in _shapes){
                if (shape.IsAt(mouse) && (SplashKit.MouseClicked(MouseButton.RightButton))){
                    if (!shape.selected){
                        shape.selected = true;
                    }
                }
            }
        }

        ///properties for number of shape
        public int ShapeCount{
            get{
                return _shapes.Count;
            }
        }

        //properties for background
        public Color Background{
            get{
                return _background;
            }
            set{
                _background = value;
            }
        }
        //properties for selected shape
        public List<Shape> SelectedShape(){
            List<Shape> _result = new List<Shape>();
            foreach (Shape shape in _shapes){
                if (shape.selected){
                    _result.Add(shape);
                }
            }
            return _result;
        }

        //method for deleting all the selected shapes
        public void delete_selected_shapes(){
            List<Shape> selected_shapes_list = SelectedShape();            
            for (int i = 0; i < selected_shapes_list.Count(); i++)
            {
                if (selected_shapes_list.Contains(selected_shapes_list[i]))
                {
                        _shapes.Remove(selected_shapes_list[i]);
                }
            }
        }
    }
}