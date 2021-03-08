using AppSeriesRegister.Classes;
using AppSeriesRegister.Enum;
using System;

namespace AppSeriesRegister
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while(userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        GetListOfSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        ViewSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();
            }

            Console.WriteLine("Thank you for use your services :D");
            Console.ReadLine();
        }

        private static void GetListOfSeries()
        {
            Console.WriteLine("List of series: ");
            var list = repository.GetList();

            if(list.Count == 0)
            {
                Console.WriteLine("There is no registered serie :/");
                return;
            }

            foreach (var serie in list)
            {
                var deleted = serie.IsItDeleted();
                Console.WriteLine("#Id {0}: - {1} {2}", serie.returnId(), serie.returnTitle(), (deleted ? "*Deleted*" : ""));
            }
        }

        private static void InsertSerie()
        {
            Console.WriteLine("Insert a new serie: ");

            foreach(int i in Enum.Genre.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.Genre.GetName(typeof(Genre), i));
            }

            Console.WriteLine("Choose and type the genre: ");
            int inputGenre = int.Parse(Console.ReadLine());

            Console.WriteLine("Type the series title: ");
            string inputTitle = Console.ReadLine();

            Console.WriteLine("Type the series release date: ");
            int inputYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Type the series description: ");
            string inputDescription = Console.ReadLine();

            Serie newSerie = new Serie(id: repository.NextId(), genre: (Genre)inputGenre, title: inputTitle, year: inputYear, description: inputDescription);

            repository.Insert(newSerie);
        }

        private static void UpdateSerie()
        {
            Console.WriteLine("Type the series Id: ");
            int indexSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.Genre.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.Genre.GetName(typeof(Genre), i));
            }
            Console.WriteLine("Choose and type the genre: ");
            int inputGenre = int.Parse(Console.ReadLine());

            Console.WriteLine("Type the series title: ");
            string inputTitle = Console.ReadLine();

            Console.WriteLine("Type the series release date: ");
            int inputYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Type the series description: ");
            string inputDescription = Console.ReadLine();

            Serie updatedSerie = new Serie(id: indexSerie, genre: (Genre)inputGenre, title: inputTitle, year: inputYear, description: inputDescription);

            repository.Update(indexSerie, updatedSerie);
        }

        private static void DeleteSerie()
        {
            Console.WriteLine("Type the series Id: ");
            int indexSerie = int.Parse(Console.ReadLine());

            repository.Delete(indexSerie);
        }

        private static void ViewSerie()
        {
            Console.WriteLine("Type the series Id: ");
            int indexSerie = int.Parse(Console.ReadLine());

            var serie = repository.ReturnById(indexSerie);

            Console.WriteLine(serie);
        }
        private static string GetUserOption()
        {
            Console.WriteLine(); ;
            Console.WriteLine("Hey there!");
            Console.WriteLine("Please, choose your option: ");
            Console.WriteLine();
            Console.WriteLine("1 - List of series");
            Console.WriteLine("2 - Insert a new serie!");
            Console.WriteLine("3 - Update a serie!");
            Console.WriteLine("4 - Delete a serie!");
            Console.WriteLine("5 - View a serie!");
            Console.WriteLine("C - Clean console!");
            Console.WriteLine("X - Exit :)");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
