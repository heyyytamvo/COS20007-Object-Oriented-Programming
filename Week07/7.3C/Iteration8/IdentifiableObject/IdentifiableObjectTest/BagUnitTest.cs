using System;
using Iteration;
using NUnit.Framework;
namespace Iteration
{
	[TestFixture]
	public class Bag_Unit_Test
	{
		private Bag _myBag;
		private Item _item1;
        [SetUp]
		public void SetUp()
		{
			_myBag = new Bag("Bag1", "This is a bag", new string[] {"my bag1"});
			_item1 = new Item("Pin Brooch", "Hand of the King's symbol", new string[] { "symbol" });
			_myBag.Inventory.Put(_item1);
		}

        ///
        [Test]
		public void Test_Bag_Locates_Item()
        {
			Assert.AreSame(_item1, _myBag.Inventory.Fetch("symbol"));
        }
		///
        [Test]
		public void Test_Bage_Locates_Itself()
        {
			_myBag.Inventory.Put(_myBag);
			Assert.AreSame(_myBag, _myBag.Inventory.Fetch("my bag1"));
        }
        [Test]
		public void Test_Return_Nothing()
        {
			Assert.IsNull(_myBag.Inventory.Fetch("sword"));
        }
        [Test]
		public void Test_Full_Description()
        {
			string expected_output = "In this Bag1 you have:\nPin Brooch, Hand of the King's symbol\n";
			string output = _myBag.Full_description;

			Assert.AreEqual(expected_output, output);
		}
        [Test]
		public void Test_Bags_In_Bag()
        {
			Bag b1 = new Bag("Bag2", "This is the first bag", new string[] { "my bag1" });
			Bag b2 = new Bag("Bag3", "This is the second bag", new string[] { "my bag2" });
			Item itemInB1 = new Item("item1", "this item is in b1", new string[] { "item1" });
			Item itemInB2 = new Item("item2", "this item is in b2", new string[] { "item2" });

			b1.Inventory.Put(b2);
			b1.Inventory.Put(itemInB1);
			b2.Inventory.Put(itemInB2);

			//assert
			Assert.AreSame(b2, b1.Locate("my bag2"));
			Assert.AreSame(itemInB1, b1.Locate("item1"));
			Assert.IsNull(b1.Locate("item2"));
		}

	}
}

