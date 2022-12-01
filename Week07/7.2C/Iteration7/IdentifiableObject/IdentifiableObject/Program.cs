using System;
using System.Collections.Generic;
namespace Iteration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //get information from the user
            Player _player;
            Console.WriteLine("Please enter the player's name: ");
            string player_name = Console.ReadLine();
            Console.WriteLine("Please enter the player's description: ");
            string player_description = Console.ReadLine();
            _player = new Player(player_name, player_description);

            //create two item and add them to player's inventory
            Item item1 = new Item("Sword", "This is the first item", new string[] {"item1", "firstItem"});
            Item item2 = new Item("Spear", "This is the second item", new string[] { "item2", "secondItem" });
            _player.Inventory.Put(item1);

            //create a bag and add to player's inventory
            Bag _bag = new Bag("Player's bag", "This is the bag of the player", new string[] { "playerBag", "bag" });
            _player.Inventory.Put(_bag);

            //create another item and add to the bag
            Item item3 = new Item("Shield", "This item is in the Player's bag", new string[] { "item3", "thirdItem" });
            _bag.Inventory.Put(item3);

            //create location for player
            Location _location = new Location("Swinburne Uni", "This is a university in Australia");
            Location _location1 = new Location("Swinburne Vietnam", "Vietnam university");
            Path path = new Path("Flight", "Vietnam Airlines", new string[] { "north" }, _location, _location1);
            _location.AddPath(path);
            _player.Location = _location;
            _location.Inventory.Put(item2);

            //Loop reading commands from the user, and getting the look command to execute them
            LookCommand _lookCommand = new LookCommand();
            MoveCommand _moveCommand = new MoveCommand();
            while (true)
            {
                Console.WriteLine("Move ... ");
                Console.WriteLine("Write your command: ");
                string user_command = Console.ReadLine();
                string[] command_array = user_command.Split(' ');
                string output = _moveCommand.Execute(_player, command_array);
                Console.WriteLine(output);
            }
        }
    }
}

