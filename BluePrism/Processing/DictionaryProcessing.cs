using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluePrism.Processing
{
    public class DictionaryProcessing
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startWord">Word to start with</param>
        /// <param name="endWord">Word to end with</param>
        /// <param name="dictionary">Dictionary list of terms to sort through</param>
        /// <returns>List of strings</returns>
        public static List<string> ProcessDictionary(string startWord, string endWord, List<string> dictionary)
        {
            // Process the words to determine which chars need switching
            int steps = CalculateSteps(startWord, endWord);

            // List of words that have been processed for character changes
            List<string> words = new List<string>();

            words.Add(startWord);

            // Loop through each step
            for (int i=steps; i>0; i--)
            {
                // We only need to correct chars that are not already correct
                words.Add(ParseDictionary(words[words.Count-1], endWord, dictionary, i));
            }

            return words;
        }

        /// <summary>
        /// Steps through the characters of the letters and assertains whether a letter switch is required
        /// </summary>
        /// <param name="startWord"></param>
        /// <param name="endWord"></param>
        /// <returns></returns>
        private static int CalculateSteps(string startWord, string endWord)
        {
            // Intersect the 2 words and create a list of matching chars
            List<Char> intersect = startWord.Intersect(endWord).ToList();

            // Convert to String and calculate length for calculation
            int countOfIntersection = (new String(endWord.Where(c => intersect.Contains(c)).ToArray())).Length;

            // Assume that startWord and endWord are the same length
            return startWord.Length - countOfIntersection;
        }

        /// <summary>
        /// Parse the dictionary file for words that can be used on the Char switch
        /// </summary>
        /// <param name="startWord">Word we are switching out</param>
        /// <param name="endWord">The end goal word</param>
        /// <param name="dictionary">Dictionary File</param>
        /// <param name="lettersLeft">How many letters we have left to change</param>
        /// <returns></returns>
        private static string ParseDictionary(string startWord, string endWord, List<string> dictionary, int lettersLeft)
        {
            char[] startWordChars = startWord.ToLower().ToCharArray(); // Convert strings to chars
            char[] endWordChars = endWord.ToLower().ToCharArray();
            foreach (var word in dictionary)
            {
                char[] wordChars = word.ToLower().ToCharArray(); // Convert string to char
                int lettersChanged = 0; // Start with no letters changed
                int lettersNeededToChange = endWord.Length; // Start assuming we need to change ever letter

                // We only care about words of equal length
                if (wordChars.Length == startWordChars.Length)
                {
                    for (int i = 0; i < startWordChars.Length; i++)
                    {
                        // If this letter has been changed increment the chage variable
                        if (startWordChars[i] != wordChars[i])
                        {
                            lettersChanged++;
                        }

                        // If this letter exists in the final word we are looking for
                        if (endWordChars[i] == wordChars[i])
                        {
                            lettersNeededToChange--;
                        }
                    }

                    // We ONLY want to make 1 change at a time and we want this change to exist in the final word
                    if ((lettersChanged == 1) && (lettersNeededToChange == (lettersLeft-1)))
                    {
                        return word;
                    }
                }
            }

            // A word to be used does not exist in this dictionary.
            throw new Exception("The dictionary provided did not contain a possible solution.");
        }
    }
}
