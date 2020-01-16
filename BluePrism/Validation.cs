using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluePrism
{
    public class Validation
    {
        /// <summary>
        /// Validate that words provided by the user are correct
        /// </summary>
        /// <param name="StartWord">String</param>
        /// <param name="EndWord">String</param>
        /// <returns>True if words are valid</returns>
        public static Boolean ValidateWords(string StartWord, string EndWord)
        {
            return (StartWord.Length == EndWord.Length);
        }
    }
}
