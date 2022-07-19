using static MovieDatabase.ListOfMovies;

namespace MovieDatabase
{
    internal class Program
    {
        static void Main()
        {
            PrintCategories();
            Console.WriteLine();
            PrintMovieList();
            Console.WriteLine();
            PrintMovieCategory("Action");
            Console.WriteLine();
            PrintMovieCategory("Comedy");
            Console.WriteLine();
            PrintMovieCategory("Drama");
            Console.WriteLine();
            PrintMovieCategory("Horror");
            //movieList.Where(s => s.GetCategory == "Action")
            //    .ToList()
            //    .ForEach(w => Console.WriteLine(w.GetTitle));
        }
    }
}