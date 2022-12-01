using System;
using Iteration;
using NUnit.Framework;
namespace Iteration
{
    [TestFixture]
	public class CommandProcessorUnitTest
	{
		CommandProcessor _commands;
		Player player;
		Item item1;
		Item item2;
		Location locationA;
		Location locationB;
		Path pathAB;

		[SetUp]
		public void SetUp()
		{
			_commands = new CommandProcessor();
			player = new Player("A", "This is player A");
			item1 = new Item("Sword", "This is the first item", new string[] { "Sword" });
			item2 = new Item("Spear", "This is the second item", new string[] { "Spear" });
			locationA = new Location("A", "This is location A");
			locationB = new Location("B", "This is location B");
			//set player at location A
			player.Location = locationA;

			//add item to location A
			locationA.Inventory.Put(item1);
			//add item to location B
			locationB.Inventory.Put(item2);

			//connect location A to location B by a path in the south
			pathAB = new Path("Door", "A big door", new string[] { "south" }, locationA, locationB);
			locationA.AddPath(pathAB);
		}

        [Test]
		public void Test_Look_At_Player()
        {
			//act
			string output = _commands.Execute(player, new string[] { "Look", "at", "me" });
			string expected = "You are A-This is player A\nYou are carrying:\n";
			//assert
			Assert.AreEqual(expected, output);
		}

        [Test]
		public void Test_Look_Arround()
        {
			//act
			string output = _commands.Execute(player, new string[] { "Look" });
			string expected = "You are in A In here you see: \r\nSword, This is the first item\n\n\r\n\nThere is an exit in the south.\r\n";
			//assert
			Assert.AreEqual(expected, output);
		}

        [Test]
		public void Test_Move()
        {
			string output = _commands.Execute(player, new string[] { "Move", "south" });
			Location expected = locationB;
			Location actual = player.Location;

			//assert
			Assert.AreSame(expected, actual);
		}
        [Test]
		public void Test_Command_error()
        {
			//act
			string output = _commands.Execute(player, new string[] { "say", "hi" });
			string expected = "Error in Command input";

			//assert
			Assert.AreEqual(expected, output);
		}
	}
}

