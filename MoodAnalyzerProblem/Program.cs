using System;

namespace MoodAnalyzerProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to mood analyzer portal!");
            MoodAnalyser moodAnalyser = new MoodAnalyser();
            Console.WriteLine("Type how you feeling right now:");
            string mood = Console.ReadLine();
            Console.WriteLine("Currently you are in: " + moodAnalyser.AnalyseMood(mood));
        }
    }
}
