using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluePrism.Dictionary
{
    public class DictionaryFile : DictionaryInterface
    {
        /// <summary>
        /// Read the contents of the Dictionary Text File and return as a List of String values
        /// </summary>
        /// <returns>List<string></returns>
        public List<string> LoadFromSource()
        {
            // Get current directory -- needed to find file for unit tests
            string solutiondir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            
            // Return the contents of the File in a list of string values
            // Need to go up one directory for tests and working solution to pass
            return new List<string>(File.ReadAllLines(solutiondir+"\\..\\BluePrism\\Dictionary\\words-english.txt"));
        }
    }
}
