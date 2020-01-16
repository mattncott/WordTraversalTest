using System;
using BluePrism;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluePrism.UnitTests
{
    [TestClass]
    public class ValidationTests
    {
        /// <summary>
        /// Unit Test to ensure that words of equal length pass validation
        /// </summary>
        [TestMethod]
        public void ValidateWords_WordsAreValid_ExpectedBehaviour()
        {
            // Arrange
            string startWord = "Matt";
            string endWord = "Mark";

            // Act
            bool valid = Validation.ValidateWords(startWord, endWord);

            // Assert
            Assert.IsTrue(valid);
        }

        /// <summary>
        /// Unit Test to ensure that words of differing lengths fails
        /// </summary>
        [TestMethod]
        public void ValidateWords_WordsAreNotEqualLengths_ExpectedBehaviour()
        {
            // Arrange
            string startWord = "Matt";
            string endWord = "James";

            // Act
            bool valid = Validation.ValidateWords(startWord, endWord);

            // Assert
            Assert.IsFalse(valid);
        }
    }
}
