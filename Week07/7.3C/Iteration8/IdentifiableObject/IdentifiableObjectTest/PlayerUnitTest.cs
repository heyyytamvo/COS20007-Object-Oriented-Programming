using System;
using System.Collections.Generic;
using Iteration;
using NUnit.Framework;
namespace Iteration
{
    [TestFixture]
    public class Player_Unit_Test //Rename this appropriately.
    {
        private Player _player1;
        private Item _item1;
        [SetUp]
        public void SetUp()
        {
            _player1 = new Player("Sir Arthur Dayne", "the Sword of the Morning");
            _item1 = new Item("The greatsword Dawn", "Sir Arthur Dayne's sword", new string[] {"weapon"});
            
        }


        ////////////////////////////////
        [Test]
        public void Test_Player_Identifiable()
        {
            //assert
            Assert.IsTrue(_player1.AreYou("me"));
            Assert.IsTrue(_player1.AreYou("inventory"));
            
        }
        ////////////////////////////////
        [Test]
        public void Test_Player_Locates_item()
        {
            //act
            _player1.Inventory.Put(_item1);
            GameObject item_located = _player1.Locate("weapon");
            //assert
            Assert.AreSame(item_located, _item1); 
        }
        ////////////////////////////////
        [Test]
        public void Test_Player_Locates_itself()
        {
            //act
            GameObject item_located = _player1.Locate("me");
            //assert
            Assert.AreSame(item_located, _player1);
        }

        ////////////////////////////////
        [Test]
        public void Test_Player_Locates_nothing()
        {
            //act
            GameObject item_located = _player1.Locate("nothing");
            //assert
            Assert.IsNull(item_located);
        }
        ////////////////////////////////
        [Test]
        public void Test_Player_Full_Description()
        {
            //act
            _player1.Inventory.Put(_item1);
            string expected_output = "You are Sir Arthur Dayne-the Sword of the Morning\nYou are carrying:\nThe greatsword Dawn, Sir Arthur Dayne's sword\n";
            string output = _player1.FullDescription;
            //assert
            Assert.AreEqual(output, expected_output);
        }
    }
}

