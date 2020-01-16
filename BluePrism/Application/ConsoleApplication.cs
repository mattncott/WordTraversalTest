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
                string StartWord;
                string EndWord;
                bool valid = false;

                // We're going to continously loop through word selection until we have 2 valid words
                do
                {
                    Console.Write("Please enter your start word: ");
                    StartWord = Console.ReadLine().ToLower();
                    Console.WriteLine("You chose: {0}", StartWord);

                    Console.Write("Please enter your end word: ");
                    EndWord = Console.ReadLine().ToLower();
                    Console.WriteLine("You chose: {0}", EndWord);

                    // Perform validation on the words
                    valid = Validation.ValidateWords(StartWord, EndWord);
                    if (!valid)
                    {
                        Console.WriteLine("Please make sure that both words are of equal length.");
                    }

                } while (!valid);

                try
                {
                    DictionaryFile DictionaryFile = new DictionaryFile();
                    List<string> Dictionary = DictionaryFile.LoadFromSource();

                    Dictionary = DictionaryProcessing.ProcessDictionary(StartWord, EndWord, Dictionary);

                    foreach (string word in Dictionary)
                    {
                        Console.WriteLine(word);
                    }
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine("The word dictionary could not be found. Please try again later.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("An unknown error occurred. Please try again later");
                }

                Console.WriteLine("Please type 'exit' to leave the application or, press enter to go again.");
                exit = Console.ReadLine().ToLower();

            } while (exit != "exit");
        }
    }
}
