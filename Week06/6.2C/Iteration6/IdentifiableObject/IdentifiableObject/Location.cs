using System;
namespace Iteration
{
	public class Location : GameObject, IHaveInventory
	{
		private Inventory _inventory;
		public Location(string name, string description) : base(name, description, new string[] { "location", "place", "room" })
		{
			_inventory = new Inventory();
		}

		public GameObject Locate(string id)
		{
			if (AreYou(id))
				return this;

			return _inventory.Fetch(id);
		}

        public Inventory Inventory
        {
            get
            {
				return _inventory;
            }
        }
	}
}

