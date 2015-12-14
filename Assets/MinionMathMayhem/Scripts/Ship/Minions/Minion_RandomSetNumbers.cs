﻿using UnityEngine;
using System.Collections;

namespace MinionMathMayhem_Ship
{
    public class Minion_RandomSetNumbers : MonoBehaviour
    {
        /*                          MINION RANDOM SET NUMBERS
         *  This class is designed to generate a specific set of numbers that each minion will be assigned.
         *   This will help to control when the 'right' answer appears to the user -- without this
         *   enforcement control and due to randomness of generated at time, time will elapse of when the
         *   user is bored and when the answer appears.  This will control what numbers each minions will have
         *   and try to make it challenging to the user if needed or easier.
         *
         *
         * STRUCTURAL DEPENDENCY NOTES:
         *      Quadratic Equation TextBox
         *           |_ Problem Box
         *      Letter_Text
         *           |_ LetterBox
         *      Game Controller
         *           |_ GameEvent
         *
         *
         * GOALS:
         *  Fetch the number ranges
         *  Fetch for the expected answer
         *  Randomize the entire number set
         *  Place the right answer in a random index
         *  Regenerate when needed
         */

        #region Declaration and Initializations
        // Number set array
            private static short[] numberSetArray = new short[20];
        // Highlight Array Index
            private static short arrayCounter = 0;
        // OPTIONS
            // Allow answers to be repeated by pure luck by the RNG.
                private static bool option_AnswersRepeated;
            // Only allow the answer to be at the middle or tail of the array.
                private static bool option_AnswerTailArray;
        // Objects
            // Problem Box - To fetch random number
                private static ProblemBox scriptProblemBox;
            // Game Event - Fetch the 'correct' answer
                private static GameEvent scriptGameEvent;
        #endregion



        /// <summary>
        ///     Unity Function
        ///     
        ///     This will be automatically called when the object is in the scene
        /// </summary>
        private void Awake()
        {
            // Fetch the Problem Box class instance
                scriptProblemBox = GameObject.FindGameObjectWithTag("RandomNumberGenerator").GetComponent<ProblemBox>();
            // Fetch the Game Event class instance
                scriptGameEvent = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameEvent>();
        }


        /// <summary>
        ///     DEBUG PURPOSES ONLY
        /// 
        ///     Output the contents within the array
        /// </summary>
        private static void Output()
        {
            // Scan the entire array and output the data on all indexes
            for (short i = 0; i < numberSetArray.Length; i++)
                Debug.Log("Array RandSet at [" + i + "] set to: " + numberSetArray[i]);
        } // Output()



        /// <summary>
        ///     Fill the array with randomized numbers
        /// </summary>
        /// <param name="useLastKnownSettings">
        ///     When true, use the previous settings as given by the function 'Access_FillArray()'.
        /// </param>
        /// <param name="answerTailArray">
        ///     When true, only allow the answer to be at the middle or tail of the array.
        ///         Default value is false
        /// </param>
        /// <param name="answersRepeated">
        ///     When true, the answers can be repeated by luck by the RNG.  When false, the repetitive answers given by the RNG will be regenerated.
        ///         Default value is true
        /// </param>
        private static void FillArray(bool useLastKnownSettings, bool answerTailArray = false, bool answersRepeated = true)
        {

            // Fill the array
            for (short i = 0; i < numberSetArray.Length; i++)
            {
                numberSetArray[i] = (short)scriptProblemBox.Access_GetRandomNumber();
            }

            // Fetch a random index
            int randKey = Random.Range(0, numberSetArray.Length);
            // Set the answer to the highlighted index
            numberSetArray[randKey] = FetchAnswer();

            Debug.Log("Answer was selected at index: " + randKey);
            Output();
        } // FillArray()



        /// <summary>
        ///     Place the answer within the array
        ///     But hopefully place the answer not at the 
        /// </summary>
        private static void FillArray_AnswerPlacement()
        {
            //if (optAnswerInBeginning)
            //{

            //}
        }



        /// <summary>
        ///     Retrive the answer as selected by the generated quadratic equation and selected index.
        /// </summary>
        /// <returns>
        ///     Index or Answer
        /// </returns>
        private static short FetchAnswer()
        {
            // Use the already implemented algorithm in GameEvent to get the answer (or Index)
                return (short)scriptGameEvent.Access_GetQuadraticEquation_Index();
        } // FetchAnswer()



        /// <summary>
        ///     Assign the minion a pre-cached number that was already generated by the array.
        ///         This will determine if that minion will have the correct answer or not.
        /// </summary>
        /// <returns>
        ///     Cached number from the array
        /// </returns>
        private static int GetNumber()
        {
            // Check to see if the array data has already been exhausted.
                GetNumber_CheckHighlightPosition();
            // Retrieve the number at array on the highlighted index.
                int value = numberSetArray[arrayCounter];
            // Increment the index highlighter
                arrayCounter++;

            return value;
        } // GetNumber()



        /// <summary>
        ///     Check the array index highlighter (or counter) and see if the array elements has been exhausted.
        ///         If the elements have been exhausted, regenerate the array again.
        /// </summary>
        private static void GetNumber_CheckHighlightPosition()
        {
            // When the array contents has been exhausted, re-generate the array.
            if (numberSetArray.Length == arrayCounter)
            {
                // Reset the highlight back to zero.
                    arrayCounter = 0;
                // Regenerate; using previous configurations
                    FillArray(true);
            } // if
        } // GetNumber_CheckHighlightPosition()



        /// <summary>
        ///     Assign the minion a pre-cached number that was already generated by the array.
        ///         This will determine if that minion will have the correct answer or not.
        /// </summary>
        /// <returns>
        ///     Cached number from the array
        /// </returns>
        public static int Access_GetNumber()
        {
            return GetNumber();
        } // GetNumber()



        /// <summary>
        ///     Regenerate the Minion's number algorithm
        /// </summary>
        /// <param name="answerTailArray">
        ///     When true, only allow the answer to be at the middle or tail of the array.
        ///         Default value is false
        /// </param>
        /// <param name="answersRepeated">
        ///     When true, the answers can be repeated by luck by the RNG.  When false, the repetitive answers given by the RNG will be regenerated.
        ///         Default value is true
        /// </param>
        public void Access_FillArray(bool answerTailArray = false, bool answersRepeated = true)
        {
            FillArray(false, answerTailArray, answersRepeated);
        } // Access_FillArray()
    }
} // 168