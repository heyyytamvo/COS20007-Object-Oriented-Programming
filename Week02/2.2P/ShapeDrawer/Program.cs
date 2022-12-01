using System;
using SplashKitSDK;
namespace ShapeDrawer
{
    public class Program
    {


        public static void Main()
        {
            new Window("Shape Drawer", 800, 600);
            Shape myShape = new Shape();
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                

                /*If  the  user  clicks  the  LeftButton  
                 * on  their  mouse,  set  the  shapes  x,  y  to  be  at  the 
                    mouse's position.             
                */
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.location_x = SplashKit.MouseX();
                    myShape.location_y = SplashKit.MouseY();
                }
                /*If the mouse is over the shape 
                 * (i.e. it is at the same point as the mouse position) 
                   and  the  user  presses  the  spacebar,
                then  change  the  Color  of  the  shape  to  a  ran-
                   dom color. 
                */
                Point2D current_mouse = SplashKit.MousePosition();

                if (myShape.IsAt(current_mouse) && SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myShape.color = Color.RandomRGB(255);
                }
                
                 myShape.Draw();
                
                
                SplashKit.RefreshScreen(60);
                
            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));


        }
    }

}
