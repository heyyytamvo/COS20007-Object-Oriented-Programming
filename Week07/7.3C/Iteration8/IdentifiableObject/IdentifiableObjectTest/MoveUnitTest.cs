using System;
using Iteration;
using NUnit.Framework;
namespace Iteration
{
    [TestFixture]
	public class MoveUnitTest
	{
		Player player;
		Location location0;
		Location location1;
		Location location2;
		Path path;
		Path path1;
		MoveCommand _moveCommand;
		[SetUp]
		public void SetUp()
		{
			player = new Player("Tam Vo", "Vietmamese");
			location0 = new Location("Vietnam", "Asia");
			location1 = new Location("Australia", "Aus");
			location2 = new Location("New Zealand", "New Zealand is small");
			player.Location = location0;
			path = new Path("Flight", "Vietnam Airlines", new string[] {"south" }, location0, location1);
			path1 = new Path("Flight", "ANZ Airlines", new string[] { "south east" }, location0, location2);
			location0.AddPath(path);
			_moveCommand = new MoveCommand();
		}

        [Test]
		public void Test_Move_Player()
        {
			//act
			_moveCommand.Execute(player, new string[] { "move", "to", "south" });

			//assert
			Location expected_player_location = location1;
			Location actual_player_location = player.Location;

			Assert.AreSame(expected_player_location, actual_player_location);
        }
        [Test]
		public void Test_Remain_Location_When_Invalid_Path()
        {
			//act
			_moveCommand.Execute(player, new string[] { "move", "to", "south east" });

			//assert
			Assert.AreSame(location0, player.Location);
        }

	}
}

