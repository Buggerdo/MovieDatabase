namespace MovieDatabase
{
    internal class Movie
    {

        private string _title;
        private string _category;

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
