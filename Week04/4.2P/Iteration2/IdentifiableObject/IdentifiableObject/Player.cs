using System;
namespace Iteration
{
	public class Player : GameObject
	{
		private Inventory _inventory;
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
			return _inventory.Fetch(id);
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
	}
}

