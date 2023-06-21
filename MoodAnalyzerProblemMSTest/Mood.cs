using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblemMSTest
{
    public class Mood
    {
        public string AnalyzeMood(string Mood)
        {
            if(Mood.ToLower().Contains("sad"))
            {
                Console.WriteLine("Sad");
                return "SAD";
            }
            else
            {
                Console.WriteLine("happy");
                return "HAPPY";
            }
        }
    }
}
