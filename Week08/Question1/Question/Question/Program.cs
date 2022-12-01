using System;
using System.Collections.Generic;
namespace Question
{
	public class Program
	{
		
		public static void Main(string[] args)
        {
			Library _myLibrary = new Library();
			Book _book1 = new Book("A Song of Ice and Fire", "George R. R. Martin", "Good");
			_myLibrary.AddResource(_book1);
			_book1.OnLoan = true;

			Book _book2 = new Book("A Study in Scarlet", "Arthur Conan Doyle", "Well");
			_myLibrary.AddResource(_book2);

			Game _game1 = new Game("GTA V", "Rockstar", "Nice");
			_myLibrary.AddResource(_game1);
			_game1.OnLoan = true;

			Game _game2 = new Game("Minecraft", "Mojang", "Well");
			_myLibrary.AddResource(_game2);

			//call HasResource on book that not being on loan, should return true
			Console.WriteLine("This book " + _book2.Name + "is in the library:");
			Console.WriteLine(_myLibrary.HasResource("A Study in Scarlet"));

			//call HasResource on book that being on loan, should return false
			Console.WriteLine("This book " + _book1.Name + "is in the library:");
			Console.WriteLine(_myLibrary.HasResource("A Song of Ice and Fire"));
		}
	}
}

