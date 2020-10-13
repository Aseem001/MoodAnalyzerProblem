using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyserFactory
    {
        /// <summary>
        /// UC 4 -  Added method CreateMoodAnalyserObject to create MoodAnalyser Object with default constructor
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructorName">Name of the constructor.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">
        /// Exception: class not found
        /// or
        /// Exception: constructor not found in the class
        /// </exception>
        public static object CreateMoodAnalyserObject(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            var result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(className);
                    var res = Activator.CreateInstance(moodAnalyserType);
                    return res;
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "Exception: class not found");
                }                
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "Exception: constructor not found");
            }
        }

        /// <summary>
        /// UC 5 - Create CreateMoodAnalyserParameterizedObject to create MoodAnalyser Object with parameterized constructor
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructorName">Name of the constructor.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">
        /// constructor not found
        /// or
        /// class not found
        /// </exception>
        public static object CreateMoodAnalyserParameterizedObject(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);

            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo construct = type.GetConstructor(new[] { typeof(string) });
                    Object obj = construct.Invoke(new object[] { message });
                    return obj;
                }
                else
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "Exception: constructor not found in the class");
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "Exception: class not found");
            }
        }        
    }
}
