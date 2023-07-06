using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyzerProblemMSTest
{
    public class MoodAnalyzerFactory
    {
        public static object CreateMoodAnalyser(string className)
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                Type moodAnalysertype = assembly.GetType(className);
                return Activator.CreateInstance(moodAnalysertype);
            }
            catch(MoodAnalyzerException)
            {
                throw new Exception("No Such Class");
            }
            catch (ArgumentNullException)
            {
                throw new Exception("Class name cannot be null");
            }
            catch (ArgumentException)
            {
                throw new Exception("InValid class Name");
            }
        }
    }
}
