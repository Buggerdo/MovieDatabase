namespace MovieDatabase
{
    internal class Movie
    {

        private string _title;
        private string _category;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public Movie(string title, string category)
        {
            Title = title;
            Category = category;
        }
    }
}
