/**************************************************************************************************
Author: Minh Nguyen
Filename: ewMain.cs
Date: 04/27/2018
Version: PA1 #2
***************************************************************************************************/

/***************************************************************************************************
Description:
Main application to validate and pass input array to driver application
***************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA1
{
    class ewMain
    {
        public static void Main(string[] args)
        {
            const string WELCOME = "WELCOME TO PA1 MAIN. WE WILL PERFORM THE FOLLOWING TESTS:\n" +
            "1/ Create 5 objects of EncryptWord class in an array and display object ID and \ninitial state\n" +
            "2/ For each object, pass a distinct word to getEncryptWord() function and displays " +
            "the list of object ID, string, encrypted string, and state\n" +
            "3/ Perform 3 guess attempts of the 5 encryptWord objects with random integers\n" +
            "and display whether the guess is right or wrong\n" +
            "4/ Show guess statistics\n" +
            "5/ Decrypt encrypted word in each object\n" +
            "6/ Reset each object to initial state\n\n";
            const string GOODBYE = "\n\nEND OF TESTS. THANKS FOR OBSERVING MY MAIN.";
            string[] TEST_STRING = { "firsthill", "beaconhill", "udistrict",
            "bellevue", "othello" };

            Console.WriteLine(WELCOME);

            if (validateInput(TEST_STRING))
            {
                ewDriver ewTest = new ewDriver(TEST_STRING);
            }
            else
                Console.WriteLine("ERROR: STRING INPUT IS NOT VALID!");
            Console.WriteLine(GOODBYE);
        }

        //Description: function to validate input array to make sure each word in the array
        //contains lower case letter, no numbers and special characters
        //Input: input array
        //Output: true = valid array; false = invalid array
        public static Boolean validateInput(string[] wordArr)
        {
            const int VALID_LOW = 97;
            const int VALID_UP = 122;
            for (int i = 0; i < wordArr.Length; i++)
            {
                string word = wordArr[i];
                for(int j = 0; j < word.Length; j++)
                {
                    if (word[j] < VALID_LOW || word[j] > VALID_UP)
                        return false;
                }
            }
            return true;
        }
            
    }
}
