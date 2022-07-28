namespace MovieDatabase
{
    internal class ListOfMovies
    {
        private static readonly string lineBreak = "====================";

        public static List<string> categories = new();

        public static List<Movie> movieList = new();

        /// <summary>
        /// prints a list of movies in a category
        /// </summary>
        /// <param name="cat">Takes in a movie category and prints all the movies int that category</param>
        public static void PrintMovieCategory(string cat)
        {
            Console.Clear();
            Console.WriteLine(lineBreak);
            Console.WriteLine();
            Console.WriteLine($"List of {cat} movies.");
            Console.WriteLine();
            Console.WriteLine(lineBreak);
            movieList.Where(s => s.Category == cat)
                .ToList()
                .ForEach(i => Console.WriteLine(i.Title));
            Console.WriteLine(lineBreak);
        }

        /// <summary>
        /// compiles a list of categorys from the list of movies
        /// </summary>
        public static void MakeCategories()
        {
            categories.Clear();
            movieList.Select(x => x.Category).Distinct()
               .ToList().ForEach(y => categories.Add(y));
            categories.Sort();
        }

        /// <summary>
        /// prints a list of movie categories
        /// </summary>
        public static void PrintCategories()
        {
            int categoryNumber = 1;

            Console.WriteLine(lineBreak);
            Console.WriteLine();
            Console.WriteLine($"List of movie categories");
            Console.WriteLine();
            Console.WriteLine(lineBreak);
            categories.ForEach(i => Console.WriteLine($"{categoryNumber++}: {i}"));
            Console.WriteLine(lineBreak);
        }

        private static readonly string path = @"..\..\..\MovieList.txt";
        /// <summary>
        /// Compiles a list of movies from text file
        /// </summary>
        public static void MakeMovieList()
        {
            string[] lines = File.ReadAllLines(path);

            foreach(string line in lines)
            {
                string[] entries = line.Split(',');
                Movie newMovie = new(entries[0], entries[1]);
                movieList.Add(newMovie);
            }
            movieList = movieList.OrderBy(x => x.Category).ThenBy(x => x.Title).ToList();
            SaveMovieList();
        }

        /// <summary>
        /// Saves the movie list back to file
        /// </summary>
        public static void SaveMovieList()
        {
            List<string> output = new();
            movieList.ForEach(m => output.Add($"{m.Title},{m.Category}"));
            File.WriteAllLines(path, output);
        }

        /// <summary>
        /// Prints the full movie list
        /// </summary>
        public static void PrintFullMovieList()
        {
            Console.Clear();
            int index = 1;
            movieList.ForEach(m => Console.WriteLine($"{index++,-3}: {m.Title,-30} {m.Category}"));
        }

        /// <summary>
        /// Adds a movie to the list
        /// </summary>
        public static void AddMovie()
        {
            string title;
            string category;
            do
            {
                Console.Clear();
                Console.Write("Please enter the movie title or exit: ");
                title = Console.ReadLine().Trim().ToUpper();
                if("exit".Equals(title.ToLower())) 
                {
                    return;
                }
                else if(title != string.Empty && !title.Contains(','))
                {
                    break;
                }
                Console.WriteLine("Empty String or invalid input.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            } while(true);

            string[] genres = { "Action", "Horror", "Drama", "Thriller", "Animation", "Comedy", "Western", "Romance", "Adventure", "Fantasy" };

            do
            {
                Console.Clear();
                Console.Write("Please enter the movie category or exit: ");
                category = Console.ReadLine().Trim();
                if(category == string.Empty || category.Contains(','))
                {
                    Console.WriteLine("Empty String or invalid input.");
                    Console.Write("Press any key to continue.");
                    Console.ReadKey();
                    continue;
                }
                else if(genres.Where(c => c.ToLower().Trim().StartsWith(category)).Any())
                {
                    string[] genresFound = genres.Where(c => c.ToLower().StartsWith(category)).ToArray();
                    if(genresFound.Length == 1)
                    {
                        foreach(var cat in genres)
                        {
                            if(genresFound[0] == cat)
                            {
                                Console.WriteLine($"You chose {cat}");
                                category = cat;
                                Movie newMovie = new(title, category);
                                if(!movieList.Where(t => t.Title.Equals(title)).Any())
                                {
                                    movieList.Add(newMovie);
                                    movieList = movieList.OrderBy(x => x.Category).ThenBy(x => x.Title).ToList();
                                    SaveMovieList();
                                    MakeCategories();
                                    return;
                                }
                                Console.Clear();
                                Console.WriteLine("The movie list already contains that movie.");
                                return;
                            }
                        }
                    }
                    Console.WriteLine("More then one category mached your input.");
                    Console.Write("Press any key to continue.");
                    Console.ReadKey();
                    continue;
                }
                else if("exit".Equals(category.ToLower()))
                {
                    return;
                }
                Console.WriteLine("Sorry I can't find that category.");
                    Console.WriteLine("Press any key to try again.");
                    Console.ReadKey();
            } while(true);
        }

        /// <summary>
        /// Removes a movie from the list
        /// </summary>
        public static void RemoveMovie()
        {
            string userInput;
            do
            {
                Console.Clear();
                PrintFullMovieList();
                Console.WriteLine();
                Console.Write("Please enter the index of the movie you want to remove or exit: ");
                userInput = Console.ReadLine().Trim();
                if(int.TryParse(userInput, out int index) && --index < movieList.Count)
                {
                    Console.WriteLine();
                    Console.Write($"Are you sure you would like to remove the movie {movieList.ElementAt(index).Title} Y/N? ");
                    string confirmation = Console.ReadLine().ToLower().Trim();
                    if(confirmation != string.Empty && "yes".StartsWith(confirmation))
                    {
                        Console.Clear();
                        movieList.RemoveAt(index);
                        SaveMovieList();
                        MakeCategories();
                        PrintFullMovieList();
                        return;
                    }
                }
                else if("exit".Equals(userInput.ToLower()))
                {
                    return;
                }
                Console.WriteLine($"Sorry {userInput} is not a valid input");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            } while(true);
        }
    }
}