using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

            Console.Write(newWord + "ay ");

        }

        static void Number(string word) // passes the number back if a number is located at the first position
        {
            Console.Write($"{word} ");
        }

        static void Vowel(string word) //passes the word back + way if a vowel is found in the first position
        {
            Console.Write(word + "way "); 
        }

        static void TwoConsonants(string word) // passes the word back if the first 2 letters are consonants with them at the end of the original word + ay this is also used for the case
        {                                     // consonant consonant vowel as per pig latin rules
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

            Console.Write(newWord + "ay ");
        }


        static void Main(string[] args)
        {

            bool keepTranslating = true; //bool to keep looping the program

            Console.WriteLine("Welcome to the Pig Latin Translator!");
            Console.WriteLine();

            while (keepTranslating) //will loop until told not to
            {

                Console.Write("Enter a word to be translated:");

                string word = Console.ReadLine().ToLower(); //converts input to lowercase

                string[] sentence = word.Split(' '); //splits the word at the space so each word can be translated independently
                if (word == "")
                {
                    Console.WriteLine("That is not a Valid input. Translating another word."); // verifies the input is not blank
                    continue;
                }


                try // part of a try block to make sure the first character is a space
                {
                    foreach (string phrase in sentence)
                    {
                        char[] wordArray = phrase.ToCharArray(); //input string to an array
                        List<char> wordList = new List<char>(wordArray); // char array of input string converted to list.

                        List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' }; //vowels
                        List<char> consonants = new List<char> { 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' }; //consonants
                        List<char> numbers= new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; //numbers


                        if (vowels.Contains(wordList[0])) // checks for a word that starts with a vowel ie. Apple
                        {
                            Vowel(phrase);
                        }
                        else if (consonants.Contains(wordList[0]) && vowels.Contains(wordList[1])) // Checks for a Consonant followed by vowel ie. Banana
                        {
                            ConsonantVowel(phrase);
                        }
                        else if (consonants.Contains(wordList[0]) && consonants.Contains(wordList[1]) && vowels.Contains(wordList[2])) // Checks if word starts with 2 consonants ie. Cherry
                        {
                            TwoConsonants(phrase);
                        }
                        else if (consonants.Contains(wordList[0]) && consonants.Contains(wordList[1]) && consonants.Contains(wordList[2])) // Checks for a word that starts with 3 consonants ie. Gymnasium
                        {
                            ConsonantVowel(phrase);
                        }
                        else if (numbers.Contains(wordList[0])) // checks if first letting of work in the input is a number
                        {
                            Number(phrase);
                        }
                    }


                        Console.WriteLine();                                  //start of loop to keep program running
                        Console.Write("Translate another line? (y/n):");
                        string choice = Console.ReadLine().ToUpper();

                        if (choice == "N")
                        {
                            keepTranslating = false;
                        Console.WriteLine();
                            Console.WriteLine("Thankyou for using the translator.");
                            Console.WriteLine("Press the Enter key to exit...");
                            Console.ReadLine();
                        }
                        else if (choice != "Y")
                        {
                            Console.WriteLine("That is not a Valid input. Translating another word.");
                            continue;
                        }                                                   //end of loop to keep program running

                    
                }
                catch // informs user a space was used as a first character, and asks them to start with a word, starts program over
                {
                    Console.WriteLine();
                    Console.WriteLine("Please start with a word.");
                    Console.WriteLine("Press the Enter key to continue...");
                    Console.ReadLine();
                }
            }
        }
    }
}
