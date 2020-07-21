using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_4.Bonus_Igpay_Atinlay
{
    class Program
    {
        static void ConsonantVowel (string word)
        {
            List<char> wordList = new List<char>();

            wordList.AddRange(word);
            int wordLength = wordList.Count;
            char firstLetter = wordList[0];

            wordList.RemoveAt(0);
            wordList.Insert(wordLength -1, firstLetter);

            string newWord = string.Join<char>("",wordList);

            Console.WriteLine(newWord+"ay");
            
        }

        static void Vowel (string word)
        {
            Console.WriteLine(word + "way");
        }

        static void TwoConsonants (string word)
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
            Console.WriteLine("Welcome to the Pig Latin Translator!");
            Console.WriteLine();
            Console.Write("Enter a word to be translated:");

            string word = Console.ReadLine().ToLower();
            char[] wordArray = word.ToCharArray();
            
            List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
            List<char> consonants = new List<char> { 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };

            if (consonants.Contains(wordArray[0]) && vowels.Contains(wordArray[1]))
            {
                ConsonantVowel(word); 
            }
            else if (vowels.Contains(wordArray[0]))
            {
                Vowel(word);
            }
            else if (consonants.Contains(wordArray[0]) && consonants.Contains(wordArray[1]))
            {
                TwoConsonants(word);
            }


        }
    }
}
