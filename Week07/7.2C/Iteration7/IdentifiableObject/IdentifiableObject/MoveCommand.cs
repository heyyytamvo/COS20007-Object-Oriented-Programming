using System;
namespace Iteration
{
	public class MoveCommand : Command
	{
		public MoveCommand() : base(new string[] { "Move" })
		{
		}

        public override string Execute(Player p, string[] text)
        {
            string direction;

            switch (text.Length)
            {
                case 1:
                    return "Where do you want to move?";
                case 2:
                    direction = text[1].ToLower();
                    break;
                case 3:
                    direction = text[2].ToLower();
                    break;
                default:
                    return "Error in move input.";
            }

            GameObject _path = p.Location.Locate(direction);
            if (_path != null)
            {
                if (_path.GetType() != typeof(Path))
                    return "Could not find the " + _path.Name;
                p.Move((Path)_path);
                return "You have moved " + _path.FirstId + " through a " + _path.Name + " to the " + p.Location.Name + "-" + p.Location.FullDescription;
            }

            return "Error";
        }
	}
}

