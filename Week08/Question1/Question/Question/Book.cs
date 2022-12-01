using System;
namespace Question
{
	public class Book : LibraryResource
	{
		private string _author;
		private string _isbn;
		public Book(string name, string author, string isbn) : base(name)
		{
			_author = author;
			_isbn = isbn;

		}

		public override string Author
        {
            get
            {
				return _author;
            }
        }


		public string ISBN
        {
            get
            {
				return _isbn;
            }
        }
	}
}

