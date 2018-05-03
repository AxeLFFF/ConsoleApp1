using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello .NET Core again!");
            Console.Write($"Enter path to audio{Environment.NewLine}");
            string audio = Console.ReadLine();
            TextToSpeechProvider.Audio2Text(audio);
            Console.ReadLine();
        }
    }
}