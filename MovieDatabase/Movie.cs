namespace MovieDatabase
{
    internal class Movie
    {
        public string Title { get; set; }

        public string Category { get; set; }

        public Movie( string title, string category)
        {         
            Title = title;
            Category = category;
        }
    }
}
