
/**************************************************************************************************
Author: Minh Nguyen
Filename: ewDriver.cs
Date: 04/27/2018
Version: PA1 #2
***************************************************************************************************/

/***************************************************************************************************
Description:
Driver application that performs the following tests:
1/ Create 5 objects of EncryptWord class in an array and display object ID and initial state
2/ For each object, pass a distinct word to getEncryptWord() function of EncryptWord class and displays
the list of object ID, string, encrypted string, and state
3/ Perform 3 guess attempts of the 5 encryptWord objects with random integers 
and display whether the guess is right or wrong
4/ Show guess statistics
5/ Decrypt encrypted word in each object
6/ Reset each object to initial state
***************************************************************************************************/

/**************************************************************************************************
Assumptions:
1/ To-be-encrypted string MUST contain lower-case letters (a- z)
2/ To-be-encrypted string MUST have more than 4 characters
3/ Guess integer for shift key must be an integer
***************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA1
{
    class ewDriver
    {
        public ewDriver()
        {
            string[] SAMPLE_STRING = { "firsthill", "beaconhill", "udistrict",
            "bellevue", "othello" };
            int GUESS_LIMIT = 26;
            int ATTEMPT_LIMIT = 3;
            encryptWord[] ewArr = new encryptWord[SAMPLE_STRING.Length];
            Console.WriteLine("LET'S CREATE 5 ENCRYPTWORD OBJECTS\n\n");
            Console.WriteLine("{0,0}{1,35}", "OBJECT", "STATE (ON = TRUE, OFF = FALSE)");
            Console.WriteLine("=========================================");
            for(int i = 0; i < ewArr.Length; i++)
            {
                ewArr[i] = new encryptWord();
                Console.WriteLine("{0,0}{1,20}",i + 1, ewArr[i].isOn());
            }
            
            Console.WriteLine("\n\nTESTING ENCRYPT: USE EACH OBJECT TO ENCRYPT A WORD\n\n");
            Console.WriteLine("{0,0}{1,10}{2,20}{3,10}", "OBJECT", "WORD", "ENCRYPT_WORD", "STATE");
            Console.WriteLine ("==============================================");
            for (int i = 0; i < SAMPLE_STRING.Length; i++)
            {
                Console.WriteLine("{0,0}{1,20}{2,15}{3,10}", i + 1, SAMPLE_STRING[i],
                    ewArr[i].getEncryptWord(SAMPLE_STRING[i]), ewArr[i].isOn());
                
            }

            Console.WriteLine("\n\nTESTING GUESS: GUESS SHIFT KEY FOR EACH OBJECT\n\n");
            Random r = new Random();
            for (int k = 0; k < ATTEMPT_LIMIT; k++)
            {
                Console.WriteLine("\nAttempt #" + (k + 1) + ":\n");
                Console.WriteLine("{0,0}{1,10}{2,15}{3,15}", "OBJECT", "GUESS", "RESULT", "STATE");
                Console.WriteLine("==============================================");
                for (int i = 0; i < SAMPLE_STRING.Length; i++)
                {
                    int guess = r.Next(1, GUESS_LIMIT + 1);
                    Console.WriteLine("{0,0}{1,15}{2,15}{3,15}", i + 1, guess,
                        ewArr[i].isShiftKey(guess), ewArr[i].isOn());
                }
            }

            Console.WriteLine("\n\nTESTING GUESS STATS FOR EACH OBJECT\n\n");
            for (int i = 0; i < SAMPLE_STRING.Length; i++)
            {
                Console.WriteLine("{0,0}{1,15}{2,10}{3,8}{4,20}{5,10}", "OBJECT", "TOTAL GUESSES", "HIGHS", "LOWS", 
                    "AVG GUESS VALUE", "STATE");
                Console.WriteLine("=======================================================================");
                Console.WriteLine("{0,0}{1,12}{2,15}{3,8}{4,20}{5,12}", i + 1, ewArr[i].getGuessCount(), 
                    ewArr[i].getHighGuess(),
                    ewArr[i].getLowGuess(), 
                    ewArr[i].getAvgGuess(), 
                    ewArr[i].isOn());
                Console.WriteLine();
            }

           
            Console.WriteLine("\n\nTESTING DECRYPT FOR EACH OBJECT\n\n");
            Console.WriteLine("{0,0}{1,20}{2,10}", "OBJECT", "DECRYPTED_WORD", "STATE");
            Console.WriteLine("====================================");
            for (int i = 0; i < SAMPLE_STRING.Length; i++)
            {
                Console.WriteLine("{0,0}{1,20}{2,15}", i + 1,
                    ewArr[i].getDecryptWord(), ewArr[i].isOn());

            }

            Console.WriteLine("\n\nTESTING RESET FOR EACH OBJECT\n\n");
            Console.WriteLine("{0,0}{1,20}", "OBJECT", "STATE AFTER RESET");
            Console.WriteLine("==========================");
            for (int i = 0; i < SAMPLE_STRING.Length; i++)
            {
                Console.WriteLine("{0,0}{1,20}", i + 1,
                     ewArr[i].isOn());

            }

        }
    }
}
