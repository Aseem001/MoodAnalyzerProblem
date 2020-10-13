﻿using System;

namespace MoodAnalyzerProblem
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to mood analyzer portal!");
            Console.WriteLine("Type how you feeling right now:" + null);
            string mood = Console.ReadLine();
            MoodAnalyser moodAnalyser = new MoodAnalyser(mood);
            moodAnalyser.AnalyseMood();
            ReflectionClass.Test();
            try
            {
                MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser",null);
            }
            catch (MoodAnalyserCustomException exception)
            {
                Console.WriteLine(exception.Message);
            }            
        }
    }
}
