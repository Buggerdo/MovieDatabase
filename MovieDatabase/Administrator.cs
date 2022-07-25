namespace MovieDatabase
{
    internal class Administrator
    {
        public static void AdministratorAccess()
        {
            do
            {
                ListOfMovies.PrintFullMovieList();
                Console.WriteLine();
                Console.WriteLine("Would you like to ADD or REMOVE a movie?");
                Console.WriteLine("Press enter to skip.");
                string userInput = Console.ReadLine().ToLower().Trim();
                if(userInput != String.Empty && "add".StartsWith(userInput))
                {
                    ListOfMovies.AddMovie();
                }
                else if(userInput != String.Empty && "remove".StartsWith(userInput))
                {
                    ListOfMovies.RemoveMovie();
                }
            } while(Program.Exit());
        }
    }
}
