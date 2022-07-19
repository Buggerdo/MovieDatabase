using static System.Console;

namespace MovieDatabase
{
    internal class ListOfMovies
    {
        public static List<Movie> movieList = new()
            {
                new Movie("bob", "Action"),
                new Movie("tom", "Comedy"),
            };

        public static void PrintMovieList()
        {
            int movieNumber = 1;
            movieList.ToList().ForEach(i => WriteLine($"{movieNumber++,-2}: {i.GetTitle,-12}{i.GetCategory}"));
        }

        public static void PrintMovieCategory(string cat)
        {
            int movieNumber = 1;
            Console.WriteLine($"List of {cat} movies.");
            movieList.Where(s => s.GetCategory == cat)
                .ToList()
                .ForEach(i => Console.WriteLine($"{movieNumber++,-2}: { i.GetTitle,-12}"));
        }
    }
}
