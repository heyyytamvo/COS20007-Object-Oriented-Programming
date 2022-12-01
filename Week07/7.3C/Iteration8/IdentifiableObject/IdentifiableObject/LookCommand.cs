using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Iteration
{
	public class LookCommand : Command
	{
		public LookCommand() : base(new string[] {"Look"})
		{
		}
        
		private IHaveInventory FetchContainer(Player p, string containerId)
        {

            if (p.AreYou(containerId))
                return p;
            return p.Locate(containerId) as IHaveInventory;

		}

        private string LookAtIn(string id, IHaveInventory container)
        {
            if (container.Locate(id) != null)
                return container.Locate(id).FullDescription;

            return "Could not find " + id + ".";
        }

		public override string Execute(Player p, string[] text)
        {
            if (text.Length == 1 && text[0] == "Look")
            {
                if (p.Location != null)
                {
                    return p.Location.FullDescription; 
                }
                return p.FullDescription;
                
            }
            if (text.Length < 3 || text.Length > 5)
            {
                return "I don't know how to look at like that";
            }

            if (text[0] != "Look")
                return "Error in look input.";

            if (text[1] != "at")
                return "What do you want to look at?";

            if (text.Length == 5)
            {
                if (text[3] != "in")
                {
                    return "What do you want to look in?";
                }
            }

        
            IHaveInventory _container = null;
            if (text.Length == 3)
            {
                _container = p as IHaveInventory;
                string _itemID = text[2];
                return LookAtIn(_itemID, _container);

            }
            if (text.Length == 5)
            {
                string _placeToLook = text[4];
                string _itemID = text[2];
                _container = FetchContainer(p, _placeToLook);

                if (_container == null)
                {
                    return "Could not find " + _placeToLook + " to look in.";
                }
                else
                {
                    return LookAtIn(_itemID, _container);
                }
                
            }
                  
            return "Executed Look Command but there are some errors";
            
        }
	}
}

