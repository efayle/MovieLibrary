using System;
using NLog.Web;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MovieLibraryAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            var logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();

            logger.Info("Program Started");

            var file = "movies.csv";

            List<int> movieID = new List<int>();
            List<string> movieTitle = new List<string>();
            List<string> movieGenre = new List<string>();

            StreamReader sr = new StreamReader(file);
            sr.ReadLine();
            // load movie data from file into memory
            while(!sr.EndOfStream) {
                string line = sr.ReadLine();
                int startingPosition = line.IndexOf('"');
                string[] array = line.Split(',');

                movieID.Add(Convert.ToInt32(array[0]));
                movieTitle.Add(array[1]);
                movieGenre.Add(array[2].Replace("|",", "));
            }
            sr.Close();

            string response;
            do {
                Console.WriteLine("Enter 1 to read movies from file.");
                Console.WriteLine("Enter 2 to add movies from file.");
                Console.WriteLine("Enter anything else to quit.");
                response = Console.ReadLine();

            } while (response == "1" || response == "2");


            logger.Info("Program Ended");
        }
    }
}
