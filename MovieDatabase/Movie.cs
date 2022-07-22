namespace MovieDatabase
{
    internal class Movie
    {     
        private readonly string Title;
        private readonly string Category;

        public Movie( string title, string category)
        {         
            Title = title;
            Category = category;
        }

        public string GetTitle { get { return Title; } }

        public string GetCategory { get { return Category; } }
    }
}
