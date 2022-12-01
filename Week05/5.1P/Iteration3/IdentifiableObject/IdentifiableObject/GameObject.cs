using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Iteration
{
	public abstract class GameObject : Identifiable_Object
	{
		private string _description;
		private string _name;

		public GameObject(string name, string desc, string[] ids) : base(ids)
		{
			_description = desc;
			_name = name;
			
		}
		//properties
		public string Name
        {
            get
            {
				return _name;
            }
        }

		public string ShortDescription
        {
            get
            {
				return $"{_name} ({base.FirstId})";

			}
        }

		public virtual string FullDescription
        {
            get
            {
				return _description;
            }
        }

	}
}

