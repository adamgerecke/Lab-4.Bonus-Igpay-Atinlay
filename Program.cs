using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_4.Bonus_Igpay_Atinlay
{
    class Program
    {
        static void ConsonantVowel(string word)
        {
            List<char> wordList = new List<char>();

            wordList.AddRange(word);
            int wordLength = wordList.Count;
            char firstLetter = wordList[0];

            wordList.RemoveAt(0);
            wordList.Insert(wordLength - 1, firstLetter);

            string newWord = string.Join<char>("", wordList);

            Console.WriteLine(newWord + "ay");

        }

        static void Vowel(string word)
        {
            Console.WriteLine(word + "way");
        }

        static void TwoConsonants(string word)
        {
            List<char> wordList = new List<char>();

            wordList.AddRange(word);
            int wordLength = wordList.Count;
            char firstLetter = wordList[0];
            char secondLetter = wordList[1];

            wordList.RemoveAt(0);
            wordList.RemoveAt(0);
            wordList.Insert(wordLength - 2, firstLetter);
            wordList.Insert(wordLength - 1, secondLetter);

            string newWord = string.Join<char>("", wordList);

            Console.WriteLine(newWord + "ay");
        }


        static void Main(string[] args)
        {
            
            bool keepTranslating = true;

            Console.WriteLine("Welcome to the Pig Latin Translator!");
            Console.WriteLine();

            while ( keepTranslating)
            {
                Console.Write("Enter a word to be translated:");

                string word = Console.ReadLine().ToLower();
                char[] wordArray = word.ToCharArray();
                List<char> wordList = new List<char>(wordArray);


                List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
                List<char> consonants = new List<char> { 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };



            
            

                if (vowels.Contains(wordList[0])) // checks for a word that starts with a vowel ie. Apple
                {
                    Vowel(word);
                }
                else if (consonants.Contains(wordList[0]) && vowels.Contains(wordList[1])) // Checks for a Consonant followed by vowel ie. Banana
                {
                    ConsonantVowel(word);
                }
                else if (consonants.Contains(wordList[0]) && consonants.Contains(wordList[1]) && vowels.Contains(wordList[2])) // Checks if word starts with 2 consonants ie. Cherry
                {
                    TwoConsonants(word);
                }
                else if (consonants.Contains(wordList[0]) && consonants.Contains(wordList[1]) && consonants.Contains(wordList[2])) // Checks for a word that starts with 3 consonants ie. Gymnasium
                {
                    ConsonantVowel(word);

                }

                Console.WriteLine();
                Console.Write("Translate another line? (y/n):");
                string choice = Console.ReadLine().ToUpper();

                if (choice == "N")
                {
                    keepTranslating = false;
                    Console.WriteLine("Thankyou for using the translator.");
                    Console.WriteLine("Press the Enter key to exit...");
                    Console.ReadLine();
                }
                else if (choice != "Y")
                {
                    Console.WriteLine("That is not a Valid input. Translating another word.");
                    continue;
                }
            }
        }
    }
}
