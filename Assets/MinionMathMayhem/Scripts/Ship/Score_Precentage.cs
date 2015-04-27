﻿using UnityEngine;
using System.Collections;

namespace MinionMathMayhem_Ship
{
    public class Score_Precentage : MonoBehaviour
    {
        /*
         * This script is designed to calculate the precentage of how much the user has gotten right within the game.
         * The purpose of the task is to take what the user has right over the total possible points and return the precentage in a form of a double.
         * For example, (right/total = double).
         * 
         * 
         * Input/Output Interactions:
         *   CalculateScorePercentageInterface([int] Earned Points\Correct, [int] Total Points Possible)
         *      return value: Double
         * 
         * GOALS:
         *   Calculate user's score
         *      (correct / total_possible) = double value
         */


        // When called by other classes or scripts; this will take the provided values and return the precentage of the score.
        public double CalculateScorePercentageInterface (int earnedPoints = 0, int totalPoints = 0)
        {
            if (totalPoints == ~0)
                return CalculateScorePercentage(earnedPoints, totalPoints);
            else
                return -1; // <!>
        } // CalculateScorePercentage();



        // Calculate the score percentage and return the value.
        private double CalculateScorePercentage (int earnedPoints, int totalPoints)
        {
            return (earnedPoints / totalPoints);
        } // CalculateScorePercentage();
    }
}