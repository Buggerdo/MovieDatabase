﻿using static System.Console;

namespace MovieDatabase
{
    internal class ListOfMovies
    {
        private static string lineBreak = "====================";

        public static List<string> categories = new();

        public static List<Movie> movieList = new();



        /// <summary>
        /// prints a list of movies in a category
        /// </summary>
        /// <param name="cat"></param>
        public static void PrintMovieCategory(string cat)
        {
            Console.Clear();
            Console.WriteLine($"List of {cat} movies.\n");
            Console.WriteLine(lineBreak);
            movieList.OrderBy(x => x.GetTitle)
                .Where(s => s.GetCategory == cat)
                .ToList()
                .ForEach(i => Console.WriteLine(i.GetTitle));
            Console.WriteLine(lineBreak);
        }


        /// <summary>
        /// compiles a list of categorys from the list of movies
        /// </summary>
        public static void GetCategories()
        {
            movieList.Select(x => x.GetCategory).Distinct()
               .ToList().ForEach(y => categories.Add(y));
            categories.Sort();
        }

        /// <summary>
        /// prints a list of movie categories
        /// </summary>
        public static void PrintCategories()
        {
            Console.Clear();
            int categoryNumber = 1;

            Console.WriteLine($"List of movie categories");
            Console.WriteLine();
            Console.WriteLine(lineBreak);
            categories.ToList()
                .ForEach(i => Console.WriteLine($"{categoryNumber++}: {i}"));
            Console.WriteLine(lineBreak);
        }

        public static void MakeMovieList()
        {
            var path = @"..\..\..\MovieList.txt";

            List<string> lines = File.ReadAllLines(path).ToList();

            foreach(var line in lines)
            {
                string[] entries = line.Split(',');
                Console.WriteLine(entries[0]);
                Movie _ = new(entries[0], entries[1]);
                movieList.Add(_);
            }
        }



    }
}