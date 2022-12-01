using System;
namespace HelloWorld
{
	public class MainClass
	{
		public static void Main(string[] args)
		{
			Message[] messages = new Message[4];
			messages[0] = new Message("Welcome back oh great educator");
			messages[1] = new Message("What a lovely name");
			messages[2] = new Message("Great name");
			messages[3] = new Message("That is a silly name");

			Message myMessage = new Message("Hello world - from Message object");
			myMessage.Print();

			Console.WriteLine("Enter name: ");
			string user_input = Console.ReadLine();

			if (!string.IsNullOrEmpty(user_input))
            {
				switch (user_input)
                {
					case "Tam":
						messages[0].Print();
						Console.ReadLine();
						break;
					case "Toney":
						messages[1].Print();
						Console.ReadLine();
						break;
					case "Tam Vo":
						messages[2].Print();
						Console.ReadLine();
						break;
					default:
						messages[3].Print();
						Console.ReadLine();
						break;
				}
            }
            else
            {
				Console.WriteLine("Please provide the name");
            }
		}
	}
}

