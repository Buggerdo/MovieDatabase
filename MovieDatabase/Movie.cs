
namespace MovieDatabase
{
    internal class Movie
    {     
        private readonly string title;
        private readonly string category;

        public Movie( string title, string category)
        {         
            this.title = title;
            this.category = category;
        }

        public string GetTitle { get { return title; } }

        public string GetCategory { get { return category; } }
    }
}
