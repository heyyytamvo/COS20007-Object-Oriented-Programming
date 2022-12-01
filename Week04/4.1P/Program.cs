using System;
using SplashKitSDK;
using System.Collections.Generic;


namespace ShapeDrawing
{
    public class Program
    {
        
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            const string window_caption = "Shape drawing";
            new Window(window_caption, 800, 600);
            ShapeKind kindToAdd = ShapeKind.Circle;
            //the line should has two point (start and end)
            int Points_of_line = 0;
            float first_coor_X = 0;
            float first_coor_Y = 0;
            float second_coor_X = 0;
            float second_coor_Y = 0;
            //boolean value to make sure user choose two points of the line
            bool finished = false;
            Drawing myListShapes = new Drawing(Color.White);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                //if the user pressed R, the program will draw a Rectangle 
                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                //if the user pressed C, the program will draw a Circle 
                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                //if the user pressed L, the program will draw a Line 
                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                
                //EXEPTION: drawing a line need the user to click twice
                //first click: is for the start point
                //second click: is for the end point
                if (kindToAdd == ShapeKind.Line)
                {
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        Points_of_line += 1;
                        Shape newShape;
                        if (Points_of_line == 1)
                        {
                            first_coor_X = SplashKit.MouseX();
                            first_coor_Y = SplashKit.MouseY();
                        }

                        if (Points_of_line == 2)
                        {
                            second_coor_X = SplashKit.MouseX();
                            second_coor_Y = SplashKit.MouseY();
                            Points_of_line = 0; //reset for creating new line
                            finished = true;
                        }

                        if (finished)
                        {
                            newShape = new MyLine(Color.Green, first_coor_X, first_coor_Y, second_coor_X, second_coor_Y);
                            myListShapes.AddShape(newShape);
                            finished = false;
                        }
                    }
                }
                else
                {
                    //if the user clicked on their left mouse, the shape
                    //will be drawn
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        Shape newShape;
                        if (kindToAdd == ShapeKind.Circle)
                        {
                            MyCircle newCircle = new MyCircle();
                            newCircle.location_x = SplashKit.MouseX();
                            newCircle.location_y = SplashKit.MouseY();
                            newShape = newCircle;
                            myListShapes.AddShape(newShape);
                        }

                        if (kindToAdd == ShapeKind.Rectangle)
                        {
                            MyRectangle newRec = new MyRectangle();
                            newRec.location_x = SplashKit.MouseX();
                            newRec.location_y = SplashKit.MouseY();
                            newShape = newRec;
                            myListShapes.AddShape(newShape);
                        }
                    }
                }


                //change the background when user pressed space
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myListShapes.Background = SplashKit.RandomRGBColor(255);
                }
                //now, call the selectsShapeAt so that
                //the backend will know which shape is selected
                myListShapes.SelectShapesAt(SplashKit.MousePosition());

                // now we will delete all the selected shapes when the
                //user pressed delete key (for mac user)  

                if (SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                    myListShapes.delete_selected_shapes();
                }
                myListShapes.Draw();

                SplashKit.RefreshScreen(60);
                SplashKit.ClearScreen();
            } while (!SplashKit.WindowCloseRequested(window_caption));
        }
    }
}
