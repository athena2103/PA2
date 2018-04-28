/**************************************************************************************************
Author: Minh Nguyen
Filename: ewMain.cs
Date: 04/27/2018
Version: PA1 #2
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
            string WELCOME = "WELCOME TO PA1 MAIN. WE WILL PERFORM THE FOLLOWING TESTS:\n" +
            "1/ Create 5 objects of EncryptWord class in an array and display object ID and \ninitial state\n" +
            "2/ For each object, pass a distinct word to getEncryptWord() function and displays " +
            "the list of object ID, string, encrypted string, and state\n" +
            "3/ Perform 3 guess attempts of the 5 encryptWord objects with random integers\n" +
            "and display whether the guess is right or wrong\n" +
            "4/ Show guess statistics\n" +
            "5/ Decrypt encrypted word in each object\n" +
            "6/ Reset each object to initial state\n\n";
            string GOODBYE = "\n\nEND OF TESTS. THANKS FOR OBSERVING MY MAIN.";
            Console.WriteLine(WELCOME);
            ewDriver test = new ewDriver();
            Console.WriteLine(GOODBYE);
        }
            
    }
}
