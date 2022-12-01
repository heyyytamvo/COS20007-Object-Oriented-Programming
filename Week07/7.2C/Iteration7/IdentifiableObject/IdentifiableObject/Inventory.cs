using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Iteration
{
	public class Inventory
	{
		private List<Item> _items = new List<Item>();
		//constructor
		public Inventory()
		{
		}

		public bool HasItem(string id)
        {
			foreach (Item item in _items)
            {
				return item.AreYou(id);
            }
			return false;
        }

		public void Put(Item item)
        {
			_items.Add(item);
        }

		public Item Take(string id)
        {
			foreach (Item item in _items)
            {
				if (item.AreYou(id))
                {
					Item tmp = item;
					_items.Remove(item);
					return tmp;
                }
            }

			return null;
        }

		public Item Fetch(string id)
        {
			
			foreach (Item item in _items)
			{
				if (item.AreYou(id))
				{
					return item;
				}
			}
			return null;
        }

		//properties
		public string ItemList
        {
            get
            {
				string itemList = "";
				foreach (Item item in _items)
                {
					string item_name = item.Name;
					itemList += item_name;
					itemList += ", ";
					string item_desc = item.FullDescription;
					itemList += item_desc;
					itemList += "\n";
                }
				return itemList;
            }
        }

	}
}

