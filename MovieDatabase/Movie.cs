
namespace MovieDatabase
{
    internal class Movie
    {     
        private string title;
        private string category;

        public Movie( string title, string category)
        {         
            this.title = title;
            this.category = category;
        }

        public string GetTitle { get { return title; } }

        public string GetCategory { get { return category; } }
    }
}
