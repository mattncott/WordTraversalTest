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
            List<string> dictionaryResult = DictionaryProcessing.ProcessDictionary(startWord, endWord, dictionaryList);

            // Assert
            Assert.IsNotNull(dictionaryResult);
        }
    }
}
