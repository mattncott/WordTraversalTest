using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluePrism.Dictionary;
using BluePrism.Processing;


namespace BluePrism.Application
{
    class ConsoleApplication: ApplicationInterface
    {
        public void Start()
        {
            string exit = "";
            do
            {
                string startWord;
                string endWord;
                bool valid = false;

                // We're going to continously loop through word selection until we have 2 valid words
                do
                {
                    Console.Write("Please enter your start word: ");
                    startWord = Console.ReadLine().ToLower();
                    Console.WriteLine("You chose: {0}", startWord);

                    Console.Write("Please enter your end word: ");
                    endWord = Console.ReadLine().ToLower();
                    Console.WriteLine("You chose: {0}", endWord);

                    // Perform validation on the words
                    valid = Validation.ValidateWords(startWord, endWord);
                    if (!valid)
                    {
                        Console.WriteLine("Please make sure that both words are of equal length.");
                    }

                } while (!valid);

                try
                {
                    DictionaryFile dictionaryFile = new DictionaryFile();
                    List<string> dictionaryList = dictionaryFile.LoadFromSource();

                    dictionaryList = DictionaryProcessing.ProcessDictionary(startWord, endWord, dictionaryList);

                    foreach (string word in dictionaryList)
                    {
                        Console.WriteLine(word);
                    }
                }
                catch (System.IO.IOException)
                {
                    Console.WriteLine("The word dictionary could not be found. Please try again later.");
                }
                catch (Exception)
                {
                    Console.WriteLine("An unknown error occurred. Please try again later");
                }

                Console.WriteLine("Please type 'exit' to leave the application or, press enter to go again.");
                exit = Console.ReadLine().ToLower();

            } while (exit != "exit");
        }
    }
}
