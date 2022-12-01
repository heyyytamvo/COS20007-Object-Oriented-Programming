using System;
using Iteration;
using NUnit.Framework;
namespace Iteration
{
	[TestFixture]
	public class Look_At_Unit_Test
	{
		LookCommand _lookCommand;
		Player _player;
		Bag _bag;
		Item _item1;
		Item _gem;
		[SetUp]
		public void SetUp()
		{
			_player = new Player("Sir Arthur Dayne", "the Sword of the Morning");
			_bag = new Bag("Bag1", "This is a bag", new string[] { "bag1" });
			_item1 = new Item("The greatsword Dawn", "Sir Arthur Dayne's sword", new string[] { "weapon" });
			_gem = new Item("GEM", "a ruby", new string[] {"gemID"});
			
			
			_lookCommand = new LookCommand();
		}

        ///test look at me
        [Test]
		public void Test_Look_At_Me()
		{
			//act
			_player.Inventory.Put(_item1);
			string expected_output = "You are Sir Arthur Dayne-the Sword of the Morning\nYou are carrying:\nThe greatsword Dawn, Sir Arthur Dayne's sword\n";
			string output = _lookCommand.Execute(_player, new string[] { "Look", "at", "inventory" });
			//assert
			Assert.AreEqual(expected_output, output);
		}
        ///test returns the gems description when looking at a gem in the player's inventory.
        ///
        [Test]
		public void Test_Look_At_Gem()
        {
			//act
			_player.Inventory.Put(_gem);
			string expected_output = "a ruby";
			string output = _lookCommand.Execute(_player, new string[] { "Look", "at", "gemID" });
			//assert
			Assert.AreEqual(expected_output, output);
		}

        ///test look at unk
        [Test]
		public void Test_Look_At_Unk()
        {
			string expected_output = "Could not find gemID.";
			string output = _lookCommand.Execute(_player, new string[] { "Look", "at", "gemID" });
			//assert
			Assert.AreEqual(expected_output, output);
		}

        ///Test look at gem in me: Returns the gem's description <summary>
        /// Test look at gem in me: Returns the gem's description
        ///when looking at a gem in the player's inventory. "look at gem in inventory" 
        [Test]
		public void Test_Look_At_Gem_In_me()
        {
			//act
			_player.Inventory.Put(_gem);
			string expected_output = "a ruby";
			string output = _lookCommand.Execute(_player, new string[] { "Look", "at", "gemID", "in", "inventory"});
			//assert
			Assert.AreEqual(expected_output, output);
		}

        ///test look at gem in bag: Returns the gems description when looking at a gem in a bag that is in the player's inventory. <summary>
        /// test look at gem in bag: Returns the gems description when looking at a gem in a bag that is in the player's inventory.
        /// </summary>        ///
        /// -----------------------------

		[Test]
		public void Test_Look_At_Gem_In_Bag()
        {
			//act
			Bag _bag2 = new Bag("bag2", "This is the second bag", new string[] { "bag2" });
			_bag2.Inventory.Put(_gem);
			_player.Inventory.Put(_bag2);
			
			
			string expected_output = "a ruby";
			string output = _lookCommand.Execute(_player, new string[] { "Look", "at", "gemID", "in", "bag2" });

			//assert
			Assert.AreEqual(expected_output, output);
		}
		
        ///test look at gem in no bag
        ///
        [Test]
		public void Test_Look_At_Gem_In_No_Bags()
        {
			//act
			string expected_output = "Could not find bag1.";
			string output = _lookCommand.Execute(_player, new string[] { "Look", "at", "gemID", "in", "bag1" });
			//assert
			Assert.AreEqual(expected_output, output);
		}

        ///test look at no gem in bag
        [Test]
		public void Test_look_at_no_gem_in_bag()
        {
			string expected_output = "Could not find gemID.";
			_player.Inventory.Put(_bag);
			string output = _lookCommand.Execute(_player, new string[] { "Look", "at", "gemID", "in", "inventory" });
			//assert
			Assert.AreEqual(expected_output, output);
		}
        ///test invalid look

        [Test]
		public void Test_Invalid_Look()
        {
			string expected_output = "Error in look input.";
			string output = _lookCommand.Execute(_player, new string[] { "hi", "where", "gem", "is"});

			Assert.AreEqual(expected_output, output);

		}
	}
}

