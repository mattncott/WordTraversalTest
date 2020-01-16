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

            startWord = startWord.ToLower();
            endWord = endWord.ToLower();

            // Process the words to determine which chars need switching
            List<bool> steps = CalculateSteps(startWord, endWord);

            // List of words that have been processed for character changes
            List<string> words = new List<string>();

            words.Add(startWord);

            int position = 0;

            // Loop through each step
            foreach (bool step in steps)
            {
                // We only need to correct chars that are not already correct
                if (!step)
                {
                    words.Add(ParseDictionary(words[words.Count-1], endWord, dictionary, position));
                }
                position++;
            }

            return words;
        }

        /// <summary>
        /// Steps through the characters of the letters and assertains whether a letter switch is required
        /// </summary>
        /// <param name="startWord"></param>
        /// <param name="endWord"></param>
        /// <returns></returns>
        private static List<bool> CalculateSteps(string StartWord, string EndWord)
        {
            char[] StartWordLetters = StartWord.ToCharArray();
            char[] EndWordLetters = EndWord.ToCharArray();

            List<bool> Steps = new List<bool>();

            for (int i = 0; i < StartWordLetters.Length; i++)
            {
                Steps.Add(StartWordLetters[i] == EndWordLetters[i]);
            }

            return Steps;
        }

        /// <summary>
        /// Parse the dictionary file for words that can be used on the Char switch
        /// </summary>
        /// <param name="StartWord">Word we are switching out</param>
        /// <param name="EndWord">The end goal word</param>
        /// <param name="Dictionary">Dictionary File</param>
        /// <param name="Position">Position of char that we are currently switching</param>
        /// <returns></returns>
        private static string ParseDictionary(string StartWord, string EndWord, List<string> Dictionary, int Position)
        {
            char[] startWordLetters = StartWord.ToCharArray();
            char[] endWordLetters = EndWord.ToCharArray();
            foreach (var word in Dictionary)
            {
                // Word is the correct length. There is no point checking words of incorrect length
                if ((word.Length == StartWord.Length))
                {

                    // Convert the word to a char array for processing
                    char[] Letters = word.ToCharArray();

                    // We are looking for errors, assume this is the word we want
                    bool adding = true;

                    // Loop through all previously checked chars up to the new one we want checking they are correct
                    for (int i = 0; i <= Position; i++)
                    {
                        if (endWordLetters[i] != word.ToCharArray()[i])
                        {
                            adding = false;
                            break;
                        }
                    }

                    // If they are, loop through existing unchecked chars ensuring they are still correct
                    if (adding)
                    {
                        for (int i = Position+1; i < EndWord.Length; i++)
                        {
                            if (startWordLetters[i] != word.ToCharArray()[i])
                            {
                                adding = false;
                                break;
                            }
                        }
                    }

                    // The word is correct, we can just return now. There is no point checking further
                    if (adding)
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
