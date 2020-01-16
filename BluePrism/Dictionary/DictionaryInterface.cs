using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluePrism.Dictionary
{
    /// <summary>
    /// Dictionary Interface to allow for loading of dictionary from multiple sources
    /// </summary>
    interface DictionaryInterface
    {
        /// <summary>
        /// Load the dictionary from a strict source specified in implementing class
        /// </summary>
        /// <returns>List of string values</returns>
        List<string> LoadFromSource();
    }
}
