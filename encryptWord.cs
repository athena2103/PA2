
/**************************************************************************************************
Author: Minh Nguyen
Filename: encryptWord.cs
Date: 4/27/2018
Version: PA1 #2
***************************************************************************************************/

/**************************************************************************************************
Description:
1/ lists functions available in Encryptword class. This class manages encrypt word object and
its behaviors (statistics) through a series of getter and mutator methods (details highlighted before
each methdod header)
2/ This class does hold a list of encrypted word to be used for decrypting later

Anticipated Use:
1/ Pass a work to receive an encrypted word in return
2/ After encryption, guess the cipher shift key and receive true/false for each guess
3/ Display statistics of guesses
4/ After encryption, decrypt the encrypted word
5/ Check state of the encryptWord object
6/ Reset the object to initiial state
***************************************************************************************************/

/**************************************************************************************************
Assumptions:
1/ To-be-encrypted word MUST be lower-case letter from a to z
2/ To-be-encrypted word MUST have more than 4 characters
3/ Shiftkey (randomly generated) is an integer from 1 to 26
4/ Guess key must be an integer

Object States:
1/ ON: when getEncryptWord() is used (Encryption takes place)
2/ OFF: initial state defined by the constructor and when getDecryptWord() is used 
(Decryption takes place)
3/ RESET: when resetState() is called to reset to initial state

Legal states:
OFF -> ON: getEncryptWord() is called
ON -> OFF: getDecryptWord() is called after getEncryptWord()
ON -> RESET: resetState() is called after encryption
RESET -> OFF: after resetState() is called

Illegal states:
1/ getDecryptWord() is called without calling getEncryptWord() first
2/ resetState() is called when object state is OFF

Legal input:
1/ A word with more than 4 lower-case letters

Illegal input:
1/ A word with less than 4 characters
2/ A word that contains number and/or special characters
3/ A word that contains upper case letters

Interface Invariants:
1/ Copy of Object is not supported
2/ CANNOT getAvgGuess() if guessCount = 0
3/ getEncryptWord() must be called before getDecryptWord() and isShiftKey()
4/ isShiftKey() must be called before getAvgGuess()
5/ After RESET, can only use getEncryptWord() before can use other functions
6/ Class user is responsible to check object's state using isOn() before using functions
***************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA1
{
    public class encryptWord
    {
        private int shiftKey;
        private Boolean state;
        private int guessCount;
        private int sumGuess;
        private int highGuessCount;
        private int lowGuessCount;
        private string encryptedWord;
        private const int CHAR_LIMIT = 26;
        private const int CHAR_START = 97;
        private readonly char[] CHAR_ARR = {'a', 'b', 'c', 'd', 'e', 'f','g', 'h', 'i', 'j', 'k','l', 'm', 'n', 'o', 'p',
        'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

        //Description: constructor to intialize random shiftkey from 1 to 26 and set guessCount, sumGuess
        //highGuessCount, lowGuessCount variales to 0. 
        //Precondition: None
        //Postcondition: Object state is OFF
        public encryptWord()
        {
            Random rand = new Random();
            this.shiftKey = rand.Next(1, CHAR_LIMIT + 1);
            this.guessCount = 0;
            this.sumGuess = 0;
            this.lowGuessCount = 0;
            this.highGuessCount = 0;
            this.state = false;

        }

        //Description: Encrypt passed string (which must meet specified assumptions)
        //by shifting each character forward by shiftKey to get encrypted char in CHAR_ARR. If character 
        //position plus shiftKey is greater than CHAR_LIMIT (26), that character will be shifted by 
        //character postion plus shiftKey minus CHAR_LIMIT (circling back to the beginning for the chart). 
        //Finally, the method returns the encrypted word. 
        //Precondition: Object state MUST be OFF or RESET
        //Postcondition: Object state is set to ON 
        public string getEncryptWord(string word)
        {
            string enWord = "";
            for (int i = 0; i < word.Length; i++)
            {
                char current;
                int newPosition = word[i] - CHAR_START + shiftKey;
                if (newPosition > CHAR_LIMIT - 1)
                    newPosition -= CHAR_LIMIT;
                current = CHAR_ARR[newPosition];
                enWord += current;
            }
            this.encryptedWord = enWord;
            this.state = true;
            return encryptedWord;
        }

        //Decription: getter method to return whether the passed integer is shift key and calls
        //private functions to tally guesses, categorize a guess in appropriate category (high or low),
        //and update sum of guess values.
        //Precondition: Object state MUST be ON
        //Postcondition: Object state remains ON
        public bool isShiftKey(int key)
        {
            setGuessCount();
            hiloGuess(key);
            setTotalGuess(key);
            return key == shiftKey;
        }

        //Descripton: return number of guesses
        //Precondition: None
        //Postcondition: Object state doesn't change
        public int getGuessCount()
        {
            return this.guessCount;
        }

        //Description: return number of high guesses
        //High guess is a guesss where guess value is greater than shiftKey
        //Precondition: None
        //Postcondition: Object state doesn't change
        public int getHighGuess()
        {
            return this.highGuessCount;
        }

        //Description: return number of low guesses 
        //Low guess is a guesss where guess value is less than shiftKey
        //Precondition: None
        //Postcondition: Object state doesn't change
        public int getLowGuess()
        {
            return this.lowGuessCount;
        }

        //Description: return average guess value.
        //Average guess value equals total guess value divided by total guess count
        //Precondition:  guessCount variable must be greater than 0
        //Postcondition: Object state doesn't change
        public double getAvgGuess()
        {
            return this.sumGuess/this.guessCount;
        }

        //Description: decrypt the currently store encrypted string
        //by shifting each character backwards by shiftKey to get decrypted char in CHAR_ARR. If character
        //position minus shiftKey is less than 0, that character will be shifted back by 
        //character postion minus shiftKey plus CHAR_LIMIT. Finally, the method returns the decrypted word.
        //In addition, it calls resetState() to set all guess statistics back to zero, and object state to
        //original state
        //Precondition: Object state MUST be ON
        //Postcondition: Object state is set to OFF
        public string getDecryptWord()
        {
            string decryptedWord = "";
            for (int i = 0; i < this.encryptedWord.Length; i++)
                {
                    char current;
                    int oldPosition = this.encryptedWord[i] - CHAR_START - shiftKey;
                    if (oldPosition < 0)
                        oldPosition += CHAR_LIMIT;
                    current = CHAR_ARR[oldPosition];
                    decryptedWord += current;
                }
                
            this.state = false;
            return decryptedWord;
           
        }

        //Description: Reset the object state. The historical encrypted
        //word will be clear and get guess statistics will be set to 0. 
        //Precondition: Object state MUST be ON
        //Postcondition: Object state is set to RESET (OFF)
        public void resetState()
        {
            this.state = false;
        }

        //Description: check if the object state is ON or OFF
        //Precondition: None
        //Postcondition: Object state doesn't change
        public bool isOn()
        {
            return this.state;
        }

       

        //Description: determine if the passed integer is a low or high guess by comparing it with
        //the shiftkey, then increment appropriate highGuessCount or lowGuessCount variable
        //Precondition: isShiftKey() is called
        //Postcondition: Object state doesn't change
        private void hiloGuess(int guess)
        {
            if (guess < this.shiftKey)
                this.lowGuessCount++;
            if (guess > this.shiftKey)
                this.highGuessCount++;
        }

        //Description: increment guessCount each time isShiftKey() is called
        //Precondition: isShiftKey() is called
        //Postcondition: Object state doesn't change
        private void setGuessCount()
        {
            this.guessCount++;
        }

        //Description: update sumGuess by passed integer value
        //Precondition: isShiftKey() is called
        //Postcondition: Object state doesn't change
        private void setTotalGuess(int guess)
        {
            this.sumGuess += guess;
        }
    }
}
