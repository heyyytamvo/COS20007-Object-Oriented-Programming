using System;
using System.Collections.Generic;
using System.Text;
namespace Iteration
{
	public class Path : GameObject
	{
		private Location _start;
		private Location _destication;
		public Path(string name, string description, string[] ids, Location start, Location destination) : base(name, description, ids)
		{
			_start = start;
			_destication = destination;
		}

		public Location Start
		{
			get
			{
				return _start;
			}
		}

		public Location Destination
		{
			get
			{
				return _destication;
			}
		}

		public override string ShortDescription
        {
            get => Name;
        }
	}
}

