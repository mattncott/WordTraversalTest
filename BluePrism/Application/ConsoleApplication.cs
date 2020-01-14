using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluePrism.Application
{
    class ConsoleApplication: ApplicationInterface
    {
        public void Start()
        {
            string exit = "";
            do
            {

                Console.Write("Please enter your start word: ");
                string startWord = Console.ReadLine();
                Console.WriteLine("You chose: {0}", startWord);

                Console.Write("Please enter your end word: ");
                string endWord = Console.ReadLine();
                Console.WriteLine("You chose: {0}", endWord);

                

                Console.WriteLine("Please type 'exit' to leave the application or, press enter to go again.");
                exit = Console.ReadLine();

            } while (exit != "exit");
        }
    }
}
