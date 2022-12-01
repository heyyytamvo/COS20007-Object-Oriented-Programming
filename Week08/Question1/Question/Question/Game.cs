using System;
namespace Question
{
	public class Game : LibraryResource
	{
		private string _develop;
		private string _contentRating;
		public Game(string name, string develop, string rating) : base(name)
		{
			_develop = develop;
			_contentRating = rating;
		}

        public override string Author
        {
            get
            {
                return _develop;
            }
        }

        public string ContentWriting
        {
            get
            {
				return _contentRating;
            }
        }
	}
}

