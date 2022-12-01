using System;
using System.Collections.Generic;
using System.Text;
namespace Iteration
{
	public class Location : GameObject, IHaveInventory
	{
		private Inventory _inventory;
		private List<Path> _paths;
		public Location(string name, string description) : base(name, description, new string[] { "location", "place", "room" })
		{
			_inventory = new Inventory();
			_paths = new List<Path>();
		}

		public GameObject Locate(string id)
		{
			if (AreYou(id))
				return this;
			foreach (Path path in _paths)
			{
				if (path.AreYou(id))
					return path;
			}
			return _inventory.Fetch(id);
		}

        public Inventory Inventory
        {
            get
            {
				return _inventory;
            }
        }

		 //create a property return a string list all the item in the location
         public string ItemListOfTheLocation
         {
            get
            {
				if (_inventory.ItemList.Length == 0)
				{
					return "";
				}

				return " In here you see: \r\n" + _inventory.ItemList;
			}
		 }
		//create a property to return the available paths
		public string PathList
        {
            get
            {
				if (_paths.Count == 0)
                {
					return "There are no paths";
                }

				if(_paths.Count == 1)
                {
					return "\r\n\nThere is an exit in the " + _paths[0].FirstId + ".\r\n";
				}

				string announment = "There are exits to the ";

				if (_paths.Count > 1)
                {
					for (int i = 0; i < _paths.Count; i++)
                    {
						announment += _paths[i].FirstId;
						announment += " and ";
                    }
                }
				return announment;
			}
        }

		//this method will add path to location
		public void AddPath(Path path)
		{
			_paths.Add(path);
		}

        public override string FullDescription
        {
            get
            {
				string result = "You are in " + base.Name + ItemListOfTheLocation;
				return result;
            }
        }
    }
}

