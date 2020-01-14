using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluePrism.Dictionary
{
    class DictionaryFile : DictionaryInterface
    {
        /// <summary>
        /// Read the contents of the Dictionary Text File and return as a List of String values
        /// </summary>
        /// <returns>List<string></returns>
        public List<string> LoadFromSource()
        {
            try
            {
                // Return the contents of the File in a list of string values
                return new List<string>(File.ReadAllLines(@"../../Dictionary/words-english.txt"));
            } 
            catch (IOException)
            {
                // If the file doesn't exist, we can return an empty list
                return new List<string>();
            }
        }
    }
}
