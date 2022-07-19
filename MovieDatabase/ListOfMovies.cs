using static System.Console;

namespace MovieDatabase
{
    internal class ListOfMovies
    {
        public static List<string> categories = new() { "Action", "Comedy", "Drama", "Horror" };

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

        public static void PrintMovieList()
        {
            int movieNumber = 1;
            Console.WriteLine("List of all movies.\n");
            movieList.OrderBy(x => x.GetCategory)
                .ThenBy(x => x.GetTitle)
                .ToList()
                .ForEach(i => WriteLine($"{movieNumber++,-2}: {i.GetTitle,-30} {i.GetCategory}"));
        }

        public static void PrintMovieCategory(string cat)
        {
            Console.WriteLine($"List of {cat} movies.\n");
            movieList.OrderBy(x => x.GetTitle)
                .Where(s => s.GetCategory == cat)
                .ToList()
                .ForEach(i => Console.WriteLine(i.GetTitle));
        }

        public static void PrintCategories()
        {
            Console.WriteLine("List of movie categories.\n");
            categories.OrderBy(x => x)
                .ToList()
                .ForEach(i => Console.WriteLine(i));
        }
    }
}
