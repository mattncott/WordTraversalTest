using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluePrism.Processing
{
    class DictionaryProcessing
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartWord">Word to start with</param>
        /// <param name="EndWord">Word to end with</param>
        /// <param name="Dictionary">Dictionary list of terms to sort through</param>
        /// <returns>List of strings</returns>
        public List<string> ProcessDictionary(string StartWord, string EndWord, List<string> Dictionary)
        {

            

            return Dictionary;
        }

        /// <summary>
        /// Calculates the minimal number of steps that will be required to calculate the solution
        /// </summary>
        /// <param name="startWord"></param>
        /// <param name="endWord"></param>
        /// <returns></returns>
        private int CalculateStepsNeeded(string startWord, string endWord)
        {
            // Intersect the 2 words and create a list of matching chars
            List<Char> intersect = startWord.Intersect(endWord).ToList();

            // Convert to String and calculate length for calculation
            int countOfIntersection = (new String(endWord.Where(c => intersect.Contains(c)).ToArray())).Length;

            // Assume that startWord and endWord are the same length
            return startWord.Length - countOfIntersection;
        }
    }
}
