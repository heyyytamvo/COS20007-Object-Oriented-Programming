using System;
using System.Collections.Generic;
using System.Text;
namespace Iteration
{
	public class CommandProcessor : Command
	{
		private List<Command> _commands;
		public CommandProcessor() : base(new string[] { "command" })
		{
			_commands = new List<Command>();
			_commands.Add(new LookCommand());
			_commands.Add(new MoveCommand());
		}

		public override string Execute(Player p, string[] text)
        {
			foreach (Command c in _commands)
			{
				if (c.AreYou(text[0]))
					return c.Execute(p, text);
			}

			return "Error in Command input";
		}
	}
}

