using System;
using Iteration;
using NUnit.Framework;
namespace Iteration
{
    [TestFixture]
    public class Item_Unit_Test //Rename this appropriately.
    {
        private Item item;
        private string[] idents = new[] {"symbol"};

        [SetUp]
        public void SetUp()
        {
            item = new Item("Pin Brooch", "Hand of the King's symbol", idents);
        }


        ////////////////////////////////
        [Test]
        public void Test_item_identifiable()
        {
            //act
            var result = item.AreYou("symbol");

            //assert
            Assert.IsTrue(result);
        }
        ////////////////////////////////
        [Test]
        public void Return_full_description()
        {
            //act

            string result = item.FullDescription;
            string expected_result = "Hand of the King's symbol";

            //assert
            Assert.AreEqual(result, expected_result);
        }

        ////////////////////////////////
        [Test]
        public void Return_short_description()
        {
            //act

            string result = item.ShortDescription;
            string expected_result = "Pin Brooch (symbol)";

            //assert
            Assert.AreEqual(result, expected_result);
        }
    }
}

