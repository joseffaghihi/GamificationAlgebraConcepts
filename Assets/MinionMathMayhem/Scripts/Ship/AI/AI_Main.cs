﻿using UnityEngine;
using System.Collections;

namespace MinionMathMayhem_Ship
{
    public class AI_Main : MonoBehaviour
    {
        /*
         *                                              GAME ARTIFICIAL INTELLIGENCE
         *                                                          MAIN
         * This is the forefront of controlling the environment based on the user's performance and mastery.  This script is a 'always alive' and monitoring
         *  as to how the user is responding to the game and how well they perform.  This is the main part of the AI that centralizes all of the AI components, 
         *  and enforces the AI components to execute by the main heartbeat fequency defined.
         *
         * NOTES:
         *  Since I am treating this like a daemon or 'always alive' monitoring service, this is going to be rather intensive with the host resources.
         *
         * STRUCTUAL DEPENDENCY NOTES:
         *      MAIN [AI]
         *          |_ AI_UserResponse
         *          |_ AI_UserMastery
         *
         * GOALS:
         *      Always running service; depends on the heartbeat frequency.
         *      Allows AI components to execute and monitor or control the environment based on the user's feedback.
         *      Try to aid the user, based on their mastery over the material, by either assisting them to learn or to challenge them.
         */

        
        
        // Declarations and Initializations
        // ---------------------------------
            // Daemon Service Update Frequency
                // LOGIC: PERIOD = 1/clock;  200 KHz ~> P = 1/2x10^5 --> P == 5x10^(-6)
                private const float daemonUpdateFreq = 0.000005f;
        // AI Components
            public AI_UserMastery scriptAI_UserMastery;
            public AI_UserResponse scriptAI_UserResponse;
        // ---------------------------------

        
        
        /// <summary>
        ///     Unity will automatically call this function.
        /// </summary>
        private void Start()
        {
            // Make sure that all of the components are all properly initialized.
                CheckReferences();
            // Run the daemon servicer
                StartCoroutine(Main());
        } // Start()



        /// <summary>
        ///     Calls all of the AI components repeatedly; the components should always depend on this function to help reduce dramatical waste of host system resources.
        /// </summary>
        /// <returns>
        ///     Returns nothing useful.
        /// </returns>
        private IEnumerator Main()
        {
            while (true)
            {
                // User's Mastery over the material
                    //scriptAI_UserMastery.Main();
                // User's generalized response rate
                    scriptAI_UserResponse.Main();


                yield return new WaitForSeconds(daemonUpdateFreq);
            } // while
        } // Main()




        /// <summary>
        ///     This function will check to make sure that all the references has been initialized properly.
        /// </summary>
        private void CheckReferences()
        {
            if (scriptAI_UserMastery == null)
                MissingReferenceError("AI Component: " + "User Mastery [AI]");
            if (scriptAI_UserResponse == null)
                MissingReferenceError("AI Component: " + "User Response [AI]");
        } // CheckReferences()



        /// <summary>
        ///     When a reference has not been properly initialized, this function will display the message within the console and stop the game.
        /// </summary>
        /// <param name="refLink">
        ///     Reference Error
        /// </param>
        private void MissingReferenceError(string refLink = "UNKNOWN_REFERENCE_NOT_DEFINED")
        {
            Debug.LogError("Critical Error: Could not find a reference to [ " + refLink + " ]!");
            Debug.LogError("  Can not continue further execution until the internal issues has been resolved!");
            Time.timeScale = 0; // Halt the game
        } // MissingReferenceError()
    } // End of Class
} // Namespace