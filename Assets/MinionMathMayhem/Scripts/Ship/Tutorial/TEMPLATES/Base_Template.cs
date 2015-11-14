﻿using UnityEngine;
using System.Collections;

namespace MinionMathMayhem_Ship
{
    public class Tutorial_GeneralScript_Template : MonoBehaviour
    {
        /*                                          TUTORIAL TEMPLATE [GENERAL SCRIPT]
         * This class is designed to offer a standard base as to how the tutorials will work with the tutorial protocol.
         *
         * HOW TO USE THIS TEMPLATE:
         *  This template creates a generalized foundation as to how the tutorial will communicate between this script and it's self.  This script will - if properly used, will
         *      communicate directly to the TutorialMain and run the approperiate instructions with no work from the developer.  However, do understand what is currently in this
         *      template is crucial and should remain untouched.
         *  This script should not be used to directly 'play' or visually demonstrate the tutorial, this script should only be used as a communication path-way.
         *      Please put all of the tutorial instructions in a dedicated script.  This will allow a better way of debugging and organizing the code structure.
         *
         * STEPS
         *  1) Copy this template to your tutorial directory
         *  2) Rename the script to your personal preference
         *  3) Tutorial objects should be 'disabled' via Unity's inspector
         *  4) Declare the important tutorial GameObject's under 'Declarations and Initializations'.
         *  5) Put the Declarations (initialized via Unity's Inspector) of the GameObject's in 'Object_Activation' function so there 'SetActive' set can be toggled.
         *  6) DONE!
         *
         *  Just be sure to use Delegate Event for 'TutorialStateEnded'; this will formally close the script.
         *
         *  The tutorial that should be demonstrated to the end-user should then be able to be called automatically if using Unity's Built-In functions
         *      Automatically Executes (ORDER SENSITIVE)
         *          http://docs.unity3d.com/Manual/class-ScriptExecution.html
         *          Awake()
         *          OnEnable()
         *          Start()
         *
         *
         * GOALS:
         *  Initalizations for the specific GameObject's required for the tutorial
         *  Execute the fundamental tutorials as required
         *  Close the tutorial once finised
         */
        /* ----- REMOVE ME!!!

                // Declarations and Initializations
                // ---------------------------------
                    // Example:
                        // Specific movie objects
                            // public GameObject objectTutorial_Movie;

                    // Delegate Event's: Tutorial ended
                         public delegate void TutorialEndedSignal();
                         public static event TutorialEndedSignal TutorialEnded;
                // ---------------------------------



                /// <summary>
                ///     Built-In Unity Function
                ///     Automatically executes once the actor has been activated within the virtual world
                /// </summary>
                private void OnEnable()
                {
                    // Subscribe to the Movie script
                         MoviePlay.TutorialStateEnded += MovieTutorial_Destroy;
                } // OnEnable()



                /// <summary>
                ///     Built-In Unity Function
                ///     Automatically executes once the actor has been deactivated within the virtual world
                /// </summary>
                private void OnDisable()
                {
                    // Unsubscribe to the Movie script
                        MoviePlay.TutorialStateEnded -= MovieTutorial_Destroy;
                } // OnDisable()



                /// <summary>
                ///     Changes the actor's activation
                /// </summary>
                /// <param name="state">
                ///     true = Actor is activated in the Virtual World
                ///     false = Actor is unactivated in the Virtual World
                /// </param>
                private void Object_Activation(bool state)
                {
                    // Example: 
                        // Movie Box
                            //objectTutorial_Movie.SetActive(state);
                } // Object_Activation()



                /// <summary>
                ///     Front-End function to activating and controlling the movie
                /// </summary>
                private void Activate_Object()
                {
                    // Enable the objects
                        Object_Activation(true);

                    // Finished
                        return;
                } // Activate_Object()



                /// <summary>
                ///     Close the tutorial sequence as it was terminated (or skipped)
                /// </summary>
                private void MovieTutorial_Destroy()
                {
                    // Turn off the objects
                        Object_Activation(false);
                    // Broadcast that we're finished
                        TutorialEnded();
                } // MovieTutorial_Destroy()




                // -------------------------------------------------
                //                 PUBLIC BRIDGES
                // -------------------------------------------------
                // DON'T TOUCH ME!

                /// <summary>
                ///     Front-End Function to activate the movie tutorial
                /// </summary>
                public void ActivateTutorial()
                {
                    Activate_Object();
                } // ActivateTutorial()



                /// <summary>
                ///     A public bridge function to forcibly destroy the tutorial immediately.
                /// </summary>
                public void Access_Destroy()
                {
                    MovieTutorial_Destroy();
                } // Access_Destroy()



----- REMOVE ME!!!!!! ----- */
    } // End of Class
} // Namespace