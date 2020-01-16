using System;
using System.Collections.Generic;
using BluePrism.Dictionary;
using BluePrism.Processing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluePrism.UnitTests
{
    [TestClass]
    public class DictionaryTests
    {
        /// <summary>
        /// Test to ensure that the dictionary file itself correctly loads
        /// </summary>
        [TestMethod]
        public void Dictionary_DictionaryFileLoads_ExpectedBehaviour()
        {
            // Arrange
            DictionaryFile dictionary = new DictionaryFile();

            // Act
            List<string> dictionaryList = dictionary.LoadFromSource();

            // Assert
            Assert.IsNotNull(dictionaryList);
        }

        /// <summary>
        /// Test to ensure that a known possible solution can be found
        /// </summary>
        [TestMethod]
        public void Dictionary_DictionaryFindsSolution_ExpectedBehaviour()
        {
            // Arrange 
            string startWord = "Matt";
            string endWord = "Mark";
            DictionaryFile dictionary = new DictionaryFile();

            // Act
            List<string> dictionaryList = dictionary.LoadFromSource();
            List<string> dictionaryResult = DictionaryProcessing.ProcessDictionary(startWord, endWord, dictionaryList, "results.txt");

            // Assert
            Assert.IsNotNull(dictionaryResult);
        }

        /// <summary>
        /// Test to ensure that a known possible solution can be found
        /// </summary>
        [TestMethod]
        public void Dictionary_DictionaryFindsSolutionFromExample_ExpectedBehaviour()
        {
            // Arrange 
            string startWord = "Spin";
            string endWord = "Spot";
            List<string> dictionaryList = new List<string>();

            // Act
            dictionaryList.Add("Spin");
            dictionaryList.Add("Spit");
            dictionaryList.Add("Spat");
            dictionaryList.Add("Spot");
            dictionaryList.Add("Span");

            List<string> dictionaryResult = DictionaryProcessing.ProcessDictionary(startWord, endWord, dictionaryList, "results.txt");

            // Assert
            Assert.IsNotNull(dictionaryResult);
        }

        /// <summary>
        /// Requirements state that a non-alpabetical dictionary could be provided. Randomise the given dictionary and test the processing solutions works still
        /// </summary>
        [TestMethod]
        public void Dictionary_DictionaryFindSolutionFromRandomList_ExpectedBehaviour()
        {
            // Arrange 
            string startWord = "Matt";
            string endWord = "Mark";
            DictionaryFile dictionary = new DictionaryFile();

            // Act
            List<string> dictionaryList = Shuffle(dictionary.LoadFromSource());
            List<string> dictionaryResult = DictionaryProcessing.ProcessDictionary(startWord, endWord, dictionaryList, "results.txt");

            // Assert
            Assert.IsNotNull(dictionaryResult);
        }

        /// <summary>
        /// Shuffle a dictionary provided for testing
        /// </summary>
        /// <param name="list">List of string terms to shuffle</param>
        /// <returns></returns>
        private List<string> Shuffle (List<string> list)
        {
            Random rng = new Random();

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
    }
}
