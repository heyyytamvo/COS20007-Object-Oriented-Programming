using System;
using Iteration;
using NUnit.Framework;
namespace Iteration
{
    [TestFixture]
	public class PathUnitTest
	{
		Location _location0;
		Location _location1;
		Location _location2;
		Path _path1;
		Path _path2;
		[SetUp]
		public void SetUp()
		{
			_location0 = new Location("My Room", "This is a bed room");
			_location1 = new Location("Hall", "It's big");
			_location2 = new Location("Soccer Field", "It's large");

			_path1 = new Path("door", "a big door",new string[] {"west"}, _location0, _location1);
			_path2 = new Path("window", "a big window", new string[] { "south" }, _location0, _location2);
		}

        [Test]
		public void Test_Add_Paths()
        {
			//act
			_location0.AddPath(_path1);

			string expected = "\r\n\nThere is an exit in the west.\r\n";
			string output = _location0.PathList;

			//assert
			Assert.AreEqual(expected, output);
        }
        [Test]
		public void Test_Location_Locate_Path()
        {
			//act
			_location0.AddPath(_path1);

			//assert
			Assert.AreSame(_path1, _location0.Locate("west"));
		}
	}
}

