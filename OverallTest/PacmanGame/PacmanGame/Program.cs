using System;
using System.Collections.Generic;
class Program
{
    public int NUMBER_OF_GHOSTS = 4;
    //--abstract class for the game character: pacman, ghost--
    abstract class Game_Character
    {
        private int X_Coordinate;
        private int Y_Coordinate;
        private bool facing_block;

        public Game_Character()
        {
            //constructing the game character
        }

        //this function allows the character to go right
        public void GoRight()
        {
            
        }

        //this function allows the character to go left
        public void GoLeft()
        {
            
        }

        //this function allows the character to go up
        public void GoUp()
        {
            
        }

        //this function allows the character to go down
        public void GoDown()
        {
            
        }

        //property for setting facing block status
        public bool FacingBlock
        {
            get
            {
                return facing_block;
            }
            set
            {
                facing_block = value;
            }
        }

        //property returning X position
        public int PositionX
        {
            get
            {
                return X_Coordinate;
            }
        }

        //property returning Y position
        public int PositionY
        {
            get
            {
                return Y_Coordinate;
            }
        }
    }

    //--Pacman Class--
    class Pacman : Game_Character
    {
        //pacman attribute
        private bool has_Power;
        private int score = 0;
        public Pacman()
        {
            //constructing our Pacman
            has_Power = false;
        }

        //function to increase the score
        public void IncreasePoint()
        {
            //in case the Character has the power
            if (has_Power)
            {
                score += 15;
            }
            else
            {
                score += 5;
            }
        }

        //properties has_power
        public bool HasPower
        {
            get
            {
                return has_Power;
            }
            set
            {
                has_Power = value;
            }
        }

        //properties score
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }
    }

    //--Ghost Class--
    class Ghost : Game_Character
    {
        public Ghost()
        {
            //constructing our ghost
        }
    }

    //--abstract class for the game object: wall, floor, gate, and food--
    abstract class Game_Object
    {
        private int X_Coordinate;
        private int Y_Coordinate;
        
        public Game_Object()
        {
            //constructing the game object
        }

        //property returning X position
        public int PositionX
        {
            get
            {
                return X_Coordinate;
            }
        }

        //property returning Y position
        public int PositionY
        {
            get
            {
                return Y_Coordinate;
            }
        }
    }

    //--Wall Class--
    class Wall : Game_Object
    {
        private int wall_width;
        private int wall_height;
        public Wall()
        {
            //constructing the wall
        }
    }

    //--Normal Food Class--
    class NormalFood : Game_Object
    {
        public NormalFood()
        {
            //constructing the normal food
        }
    }

    //--Power Food Class--
    class PowerFood : Game_Object
    {
        public PowerFood()
        {
            //constructing the power food
        }
    }

    //--Map Class _ this class is a moderator containing all the class above--
    class Map
    {
        public bool game_over = false;
        public Pacman _myPacman;
        public static List<Ghost> _List_Of_Ghost;
        public List<Wall> _List_Of_Wall;
        public List<NormalFood> _List_Of_NormalFood;
        public List<PowerFood> _List_Of_PowerFood;

        //generating 4 ghosts
        //every 30 seconds, we will call this function again
        public void Generating_Ghost()
        {
            if (_List_Of_Ghost.Count < 4)
            {
                Ghost newGhost = new Ghost();
                _List_Of_Ghost.Add(newGhost);
            }
        }

        //setting up the wall (or maze)
        public void Setting_Up_Wall()
        {

        }

        //setting up position for normal food and power food
        public void Setting_Food()
        {

        }

        //function to check the collision between pacman and 4 ghost
        public void Check_Pacman_And_Ghosts()
        {
            //in case the pacman has power
            foreach (Ghost ghost in _List_Of_Ghost)
            {
                if (_myPacman.PositionX == ghost.PositionX && _myPacman.PositionY == ghost.PositionY)
                {
                    //lines of code that deleting the ghost

                    return;
                }
            }

            //in case the pacman does not have the power
            foreach (Ghost ghost in _List_Of_Ghost)
            {
                if (_myPacman.PositionX == ghost.PositionX && _myPacman.PositionY == ghost.PositionY)
                {
                    //game over
                    game_over = true;
                    return;
                }
            }
        }

        //function to check the collision between pacman and food
        public void Check_Pacman_And_Food()
        {
            //in case the pacman eat normal food
            foreach (NormalFood food in _List_Of_NormalFood)
            {
                if (_myPacman.PositionX == food.PositionX && _myPacman.PositionY == food.PositionY)
                {
                    //lines of code that deleting the ghost
                    _myPacman.IncreasePoint();
                    return;
                }
            }

            //in case the pacman eat power food
            foreach (PowerFood food in _List_Of_PowerFood)
            {
                if (_myPacman.PositionX == food.PositionX && _myPacman.PositionY == food.PositionY)
                {
                    //lines of code that deleting the ghost
                    _myPacman.HasPower = true;
                    _myPacman.IncreasePoint();
                    return;
                }
            }
        }

        //function to check the collision between pacman and walls
        public void Check_Pacman_And_Walls()
        {
            ////
        }
    }

}