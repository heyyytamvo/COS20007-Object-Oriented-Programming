using System;
using Iteration;
using NUnit.Framework;
namespace Iteration
{
    [TestFixture]
    public class Inventory_Unit_Test //Rename this appropriately.
    {
        private Inventory _inventory;
        private Item _item1;
        private Item _item2;
        [SetUp]
        public void SetUp()
        {
            _inventory = new Inventory();
            _item1 = new Item("Pin Brooch", "Hand of the King's symbol", new string[] { "symbol" });
            _item2 = new Item("The greatsword Dawn", "Sir Arthur Dayne's sword", new string[] { "weapon" });
        }


        ////////////////////////////////
        [Test]
        public void Test_Find_Item()
        {
            //act
            _inventory.Put(_item1);

            //assert
            Assert.IsTrue(_inventory.HasItem("symbol"));
        }
        ////////////////////////////////
        [Test]
        public void Test_No_Item_find()
        {
            //assert
            Assert.IsFalse(_inventory.HasItem("Weapon"));
        }

        ////////////////////////////////
        [Test]
        public void Test_Fetch_Item()
        {
            //act
            _inventory.Put(_item1);
            Item received_item = _inventory.Fetch("symbol");

            //assert
            Assert.IsTrue(_inventory.HasItem("symbol"));
        }
        ////////////////////////////////
        [Test]
        public void Test_Take_Item()
        {
            //act

            Item taken_item = _inventory.Take("symbol");

            //assert
            Assert.IsFalse(_inventory.HasItem("symbol"));
        }
        ////////////////////////////////
        
        [Test]
        public void Test_Item_List()
        {
            //act

            _inventory.Put(_item1);
            _inventory.Put(_item2);

            string expected_output = "Pin Brooch, Hand of the King's symbol\nThe greatsword Dawn, Sir Arthur Dayne's sword\n";
            string output = _inventory.ItemList;
            //assert
            Assert.AreEqual(output, expected_output);
        }
        
    }
}

