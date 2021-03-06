using AppSeriesRegister.Classes;
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
                        //InsertSerie();
                        break;
                    case "3":
                        //UpdateSerie();
                        break;
                    case "4":
                        //DeleteSerie();
                        break;
                    case "5":
                        //ViewSerie();
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
                Console.WriteLine("#Id {0}: - {1}", serie.returnId(), serie.returnTitle());
            }
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
