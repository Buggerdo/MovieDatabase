using static MovieDatabase.ListOfMovies;

namespace MovieDatabase
{
    internal class Program
    {
        static void Main()
        {

            PrintMovieList();
            Console.WriteLine();
            PrintMovieCategory("Action");
            Console.WriteLine();
            PrintMovieCategory("Comedy");
            //movieList.Where(s => s.GetCategory == "Action")
            //    .ToList()
            //    .ForEach(w => Console.WriteLine(w.GetTitle));
        }
    }
}