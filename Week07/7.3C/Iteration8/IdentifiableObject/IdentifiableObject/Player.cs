using System;
namespace Iteration
{
	public class Player : GameObject, IHaveInventory
	{
		private Inventory _inventory;
		private Location _location;
		public Player(string name, string desc) : base(name, desc, new string[] { "me", "inventory"})
		{
			_inventory = new Inventory();
		}

		public GameObject Locate(string id)
        {
			if (AreYou(id))
			{
				return this;
			}

			if (_inventory.Fetch(id) != null)
            {
				return _inventory.Fetch(id);
			}

			if (_location != null)
            {
				return _location.Locate(id);
            }

			return null;
		}

		//this function will change the player's location
		public void Move(Path path)
		{
			if (path.Destination != null)
			{
				_location = path.Destination;
			}
		}


		//properties
		public override string FullDescription
		{
            get
            {
				return $"You are {this.Name}-{base.FullDescription}\nYou are carrying:\n{_inventory.ItemList}";
			}
		}

		public Inventory Inventory
        {
			get
			{
				return _inventory;
			}
        }

		public Location Location
        {
            get
            {
				return _location;
            }
            set
            {
				_location = value;
            }
        }
	}
}

