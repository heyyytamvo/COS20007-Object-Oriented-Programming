using System;
namespace Question
{
	public abstract class LibraryResource
	{
		private string _name;
		private bool _onLoan;

        public LibraryResource(string name)
        {
            _name = name;
            _onLoan = false;
        }

		public string Name
        {
            get
            {
                return _name;
            }
        }

        public abstract string Author
        {
            get;
        }

		public bool OnLoan
        {
            get
            {
				return _onLoan;
            }

            set
            {
                _onLoan = value;
            }
        }

	}
}

