using NUnit.Framework;
using System;
using Iteration;

namespace Iteration
{
    [TestFixture]
    public class Identifiable_Object_Test //Rename this appropriately.
    {
        private Identifiable_Object id;
        
        [SetUp]
        public void SetUp()
        {
            id = new Identifiable_Object(new string[] { "id1", "id2" });
        }


        ////////////////////////////////
        [Test]
        public void TestAreYou_id1_expectTrue()
        {
            //act
            var result = id.AreYou("id1");

            //assert
            Assert.IsTrue(result);
        }
        ////////////////////////////////
        [Test]
        public void TestAreYouNot_id3_expectFalse()
        {
            //act
            var result = id.AreYou("id3");

            //assert
            Assert.IsFalse(result);
        }
        ////////////////////////////////
        [Test]
        public void TestAreYouCaseSensative_ID1_expectTrue()
        {
            //act
            var result = id.AreYou("ID1");

            //assert
            Assert.IsTrue(result);
        }

        ////////////////////////////////

        [Test]
        public void TestFirstID_expect_id1()
        {
            //act
            var result = id.FirstId;

            //asser
            Assert.AreEqual(result, "id1");
        }
        ////////////////////////////////
        ///
        [Test]
        public void TestAddID()
        {
            id.Add_Identifier("id3");
            Assert.That(id.AreYou("id3"), Is.True);
        }
    }
}
