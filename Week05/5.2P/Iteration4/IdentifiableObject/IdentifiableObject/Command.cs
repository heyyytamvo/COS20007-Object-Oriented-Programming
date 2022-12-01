﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Iteration
{
	public abstract class Command : Identifiable_Object
	{
		public Command(string[] ids) : base(ids)
		{
		}
		public abstract string Execute(Player p, string[] text);
	}
}


