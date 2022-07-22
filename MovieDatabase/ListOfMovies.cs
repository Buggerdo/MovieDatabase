using static System.Console;

namespace MovieDatabase
{
    internal class ListOfMovies
    {
        public static List<string> categories = new();

        public static List<Movie> movieList = new()
            {
                new Movie("10,000 BC", "Action"),
                new Movie("Apollo 13", "Drama"),
                new Movie("Catch Me If You Can", "Drama"),
                new Movie("Mrs. Doubtfire", "Comedy"),
                new Movie("The Talented Mr. Ripley", "Drama"),
                new Movie("Groundhog Day", "Comedy"),
                new Movie("Paycheck", "Action"),
                new Movie("Cellular", "Action"),
                new Movie("Speed", "Action"),
                new Movie("Die Hard", "Action"),
                new Movie("Paranormal Activity", "Horror"),
                new Movie("The Exorcist", "Horror"),
                new Movie("Anchorman", "Comedy"),
                new Movie("Office Space", "Comedy"),
                new Movie("An American Girl Holiday", "Drama"),
                new Movie("Titanic", "Drama"),
                new Movie("Edward Scissorhands", "Drama"),
                new Movie("The Black Phone", "Horror"),
                new Movie("Incantation", "Horror"),
            };



        /// <summary>
        /// prints a list of movies in a category
        /// </summary>
        /// <param name="cat"></param>
        public static void PrintMovieCategory(string cat)
        {
            Console.Clear();
            Console.WriteLine($"List of {cat} movies.\n");
            movieList.OrderBy(x => x.GetTitle)
                .Where(s => s.GetCategory == cat)
                .ToList()
                .ForEach(i => Console.WriteLine(i.GetTitle));
        }

        /// <summary>
        /// prints a list of movie categories
        /// </summary>
        public static void PrintCategories()
        {
            Console.Clear();
            int categoryNumber = 1;
            Console.WriteLine("List of available movie categories.");
            Console.WriteLine("Enter the category you would like to see.");
            Console.WriteLine("Or you can select a category by index numbers.\n");
            categories.ToList()
                .ForEach(i => Console.WriteLine($"{categoryNumber++}: {i}"));
        }


        /// <summary>
        /// compiles a list of categorys from the list of movies
        /// </summary>
        public static void GetCategories()
        {
             movieList.Select(x => x.GetCategory).Distinct()
                .ToList().ForEach(y => categories.Add(y));
        }
    }
}