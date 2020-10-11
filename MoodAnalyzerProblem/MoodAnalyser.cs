using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerProblem
{
    class MoodAnalyser
    {
        public string AnalyseMood(string message)
        {
            if (message.ToUpper().Contains("SAD"))
                return "Sad Mood";
            else
                return "Happy Mood";
        }

    }
}
