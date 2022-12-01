using System;
using Iteration;
using NUnit.Framework;
namespace Iteration
{
	[TestFixture]
	public class LocationUnitTest
	{
		private Player _player;
		private Location _location;
		private Item _item;
		private Bag _bag;
        [SetUp]
		public void SetUp()
		{
			_player = new Player("Eddard Stark", "head of House Stark");
			_location = new Location("Winterfell", "capital of the Kingdom of the North");
			_bag = new Bag("Bag Number 1", "This is the first bag", new string[] { "bag1", "firstbag" });
			_item = new Item("Ice", "a Valyrian steel greatsword", new string[] { "weapon" });
			_bag.Inventory.Put(_item);
			_player.Inventory.Put(_bag);
			_player.Location = _location;
		}

		[Test]
		public void Test_Location_Can_Identify_themselve()
		{
			//act
			var result = _location.Locate("place");
			//assert
			Assert.AreEqual(result, _location);
		}

        [Test]
		public void Test_Location_Can_Locate_Items_They_Have()
        {
			//act
			_location.Inventory.Put(_item);
			//asser
			Assert.AreEqual(_item, _location.Locate("weapon"));
        }

		[Test]
		public void Test_Player_Can_Locate_Items_In_Their_Location()
		{
			//act
			_location.Inventory.Put(_item);
			//assert
			Assert.AreEqual(_item, _player.Locate("weapon"));
		}
	}
}

