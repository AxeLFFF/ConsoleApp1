using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello .NET Core again!");
            Console.Write($"Enter city name{Environment.NewLine}");
            string city = Console.ReadLine();
            Weather2Base w = new Weather2Base(city);
            string input = default(string);
            while(input != "c" || input != "exit")
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "update":
                        w.UpdateWeatherAsync().Wait();
                        break;
                    default:
                        w.ShowLastNotes(Convert.ToInt32(input));
                        break;
                }
            }
        }
    }
}