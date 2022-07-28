namespace MovieDatabase
{
    internal class Movie
    {
        private readonly string _title;
        private readonly string _category;

        public string Title
        {
            get { return _title; }
        }

        public string Category
        {
            get { return _category; }
        }

        public Movie(string title, string category)
        {
            _title = title;
            _category = category;
        }
    }
}