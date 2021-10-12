using System;

namespace DIO.Series
{
    class Program
    {   

        static RepositorySerie repository = new RepositorySerie();

        static void Main(string[] args)
        {   
            string userOption = ObtainUserOptions();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListingSeries();
                        break;
                    case "2":
                        InsertSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        EraseSeries();
                        break;
                    case "5":
                        ViewSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = ObtainUserOptions();

            }

            Console.WriteLine("Thanks to user ur services! :)");
            Console.ReadLine();
        }


        private static void EraseSeries()
        {
            Console.Write("Type id serie to remove:");
            int idSerie = int.Parse(Console.ReadLine());

            Console.Write("Are u sure about that? 1 to agree 0 to decline");
            int answ = int.Parse(Console.ReadLine());

            if (answ == 1) {
                repository.Erase(idSerie);
            }
            else 
            { 
                Console.Write("Canceled");
            }
            //repository.Erase(idSerie);
            Console.Write("Sucess!");
        }

        private static void ViewSeries()
        {
            Console.WriteLine("Type series id to visualize: ");
            int idSerie =   int.Parse(Console.ReadLine());

            var serie = repository.ReturningById(idSerie);

            Console.WriteLine(serie);
        }

        private static void UpdateSeries()
        {
            Console.Write("Type id serie: ");
            int idSerie = int.Parse(Console.ReadLine());


            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Type a genre: ");
            int inputGenre = int.Parse(Console.ReadLine());

            Console.Write("Type series title: ");
            string inputTitle = Console.ReadLine();

            Console.Write("Type the series release year: ");
            int inputRelease = int.Parse(Console.ReadLine());

            Console.Write("Type series description: ");
            string inputDescription = Console.ReadLine();

            Serie UpdateSeries = new Serie(id: idSerie,
                                        genre: (Genre)inputGenre,
                                        title: inputTitle,
                                        year: inputRelease,
                                        description: inputDescription);
            
            repository.Update(idSerie, UpdateSeries);

        }

        private static void ListingSeries()
        {
            Console.WriteLine("Listing Series..");

            var listt = repository.Listing();

            if (listt.Count == 0)
            {
                Console.WriteLine("Any serie subscribed.");
                return;
            }

            foreach (var serie in listt)
            {   
                var erased = serie.returnErased();
                
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.returningId(), serie.returningTitle(), (erased ? "*Erased-" : ""));
            }
        }

        private static void InsertSeries()
        {
            Console.WriteLine("Add a new one");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }

            Console.Write("Type a genre (between the options): ");
            int inputGenre = int.Parse(Console.ReadLine());

            Console.Write("Type the serie title: ");
            string inputTitle = Console.ReadLine();

            Console.Write("Type the release year of the serie: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Type the serie description: ");
            string inputDescription = Console.ReadLine();

            Serie newSerie = new Serie(id: repository.NextId(),
                                       genre: (Genre)inputGenre,
                                       title: inputTitle,
                                       year: year,
                                       description: inputDescription);   

            repository.Insert(newSerie);
        }


        private static string ObtainUserOptions()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("-=- Welcome to DIO SERIES -=-");
            Console.WriteLine("¨¨¨¨¨ W u want to do? ¨¨¨¨¨¨¨");
            Console.WriteLine("");
            
            Console.WriteLine("1 - Listing Series");
            Console.WriteLine("2 - Add a new one");
            Console.WriteLine("3 - Update Series");
            Console.WriteLine("4 - Erase Serie");
            Console.WriteLine("5 - Visualize Serie");
            Console.WriteLine("C - Screen Clean");
            Console.WriteLine("X - Exit");

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
