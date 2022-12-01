using System;
using System.Collections.Generic;
namespace Iteration
{
	public class Bag : Item, IHaveInventory
	{
		private Inventory _inventory;
		public Bag(string name, string desc, string[] ids) : base(name, desc, ids) 
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

		public string Full_description
        {
            get
            {
				return $"In this {this.Name} you have:\n" + _inventory.ItemList;
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

