using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblemMSTest
{
    public class MoodAnalyzerException : Exception
    {
        public enum ExceptionType
        {
            NULL_MOOD,EMPTY_MOOD
        }
        private readonly ExceptionType type;
        public MoodAnalyzerException(ExceptionType type,string message):base(message)
        {
            this.type = type;
        }
    }
}
