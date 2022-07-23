using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    internal class Administrator
    {
        public static void AdministratorAccess()
        {
            Console.Clear();
            foreach(var movie in ListOfMovies.movieList)
            {
                Console.WriteLine($"{movie.Title} {movie.Category}");
            }
            Console.WriteLine("Hey");
        }
    }
}
