using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyzerProblemMSTest
{
    public class MoodAnalyzerReflector
    {
        public static object CreateMoodAnalyser(string  className)
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
        public static object CreateMoodAnalyzers(string className, string constructorParameter)
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                Type moodAnalyzerType = assembly.GetType(className);
                ConstructorInfo constructor = moodAnalyzerType.GetConstructor(new[] { typeof(string) });

                if (constructor == null)
                    throw new Exception("No such constructor error");

                return Activator.CreateInstance(moodAnalyzerType, constructorParameter);
            }
            catch (ArgumentNullException)
            {
                throw new Exception("Class name or constructor parameter cannot be null");
            }
            catch (ArgumentException)
            {
                throw new Exception("Invalid class name or constructor parameter");
            }
            catch (Exception)
            {
                throw new Exception("Error occurred while creating mood analyzer");
            }
        }
        public static string InvokeAnalyzeMood(string message)
        {
            try
            {
                object moodAnalyzerObject = Activator.CreateInstance(typeof(Mood), message);
                MethodInfo analyzeMoodMethod = moodAnalyzerObject.GetType().GetMethod("AnalyzeMood");
                if(analyzeMoodMethod == null)
                {
                    throw new Exception("No Such Method Error");
                }
                return (string)analyzeMoodMethod.Invoke(moodAnalyzerObject, null);
            }
            catch (ArgumentNullException)
            {
                throw new Exception("Message cannot be null");
            }
            catch (ArgumentException)
            {
                throw new Exception("Invalid message");
            }
            catch (Exception)
            {
                throw new Exception("Error occurred while invoking AnalyzeMood method");
            }
        }
    }
}
