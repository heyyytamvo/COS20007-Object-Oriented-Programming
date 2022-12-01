using System;
using SplashKitSDK;
using System.Collections.Generic;
using System.Linq;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            const string window_caption = "Shape drawing";
            new Window(window_caption, 800, 600);
            Drawing obj = new Drawing(Color.White);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                
                ///Check if the user has clicked the left mouse button, 
                /// and if they have add a new
                ///Shape to your Drawing object based on the mouse's location.
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape new_shape = new Shape();
                    new_shape.location_x = SplashKit.MouseX();
                    new_shape.location_y = SplashKit.MouseY();
                    //add the shape to the obj list
                    obj.AddShape(new_shape); 
                }
                
                /*
                

                */

                //change the background when user pressed space
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    obj.Background = SplashKit.RandomRGBColor(255);
                }               
                //now, call the selectsShapeAt so that the backend will know which shape is selected
                obj.SelectShapesAt(SplashKit.MousePosition());
                
                 
                
                
                //now we will delete all the selected shapes when the 
                //user pressed delete key (for mac user)  
                
                if (SplashKit.KeyTyped(KeyCode.CKey)){
                    obj.delete_selected_shapes();
                }
                obj.Draw();

                SplashKit.RefreshScreen(60);
                SplashKit.ClearScreen();
                
            } while (!SplashKit.WindowCloseRequested(window_caption));


        }
    }

}
