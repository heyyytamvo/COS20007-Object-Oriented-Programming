using System;
namespace ISStracking
{
	public class AstronautCommand : Command
	{
        
        public AstronautCommand() 
		{
		}

        public string Execute(List<Astronaut> people)
        {
            string result = "";
            foreach (Astronaut person in people)
            {
                result += "Name: " + person.GetFullName + ". " + person.Location();
                result += "\n";
            }
            return result;
        }
	}
}

