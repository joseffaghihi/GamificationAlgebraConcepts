﻿using UnityEngine;
using System.Collections;

namespace MinionMathMayhem_Ship
{
    public class SpawnController : MonoBehaviour
    {
        /*                    SPAWNER CONTROLLER
         * This class will simply send a signal to the spawner actors to summon the minion actors into the scene.
         *  
         * GOALS:
         *  Determine the next spawn
         *  Send spawn signal to the spawners
         */



        // Declarations and Initializations
        // ---------------------------------
            // Time when the next minion should spawn
                private float nextSpawn;
            // How many minions are to be spawned within 60 seconds of time
                // Can be manipulated within Unity's Inspector
                public float spawnRate;
            // Grace-Timer for when the spawners should be activated
                // Lock variable; this will avoid the gracePeriod to be reset in an endless loop.
                    private bool gracePeriodLockOut = false;
                // Grace Timer Duration
                    public float gracePeriodTimer = 2.5f;
            // Accessors and Communication
                // GameController
                    public GameController scriptGameController;
                // Game Event
                    public GameEvent scriptGameEvent;
                // Spawner Broadcast Event
                    public delegate void ActivateSpawnPoint();
                    public static event ActivateSpawnPoint EnableSpawnPoint;
        // ----


        

        // Signal Listener: Detected
        private void OnEnable()
        {
            GameEvent.RequestGraceTime += GraceTimer;
            GameController.RequestGraceTime += GraceTimer;
        } // OnEnable()



        // Signal Listener: Deactivate
        private void OnDisable()
        {
            GameEvent.RequestGraceTime -= GraceTimer;
            GameController.RequestGraceTime -= GraceTimer;
        } // OnDisable()



        // This function is immediately executed once the actor is in the game scene.
        private void Start()
        {
            // First make sure that all the scripts and actors are properly linked
                CheckReferences();
            // Determine the spawn rate
                CalcNextSpawnTime();
            // Spawn Control
                StartCoroutine(SpawnDriver());
        } // Start()



        // This function is always called on each frame.
        private IEnumerator SpawnDriver()
        {
            while (true) // Never ending
            {
                // ----
                // Check to see if the spawner is activated
                if (scriptGameController.SpawnMinions == !false && scriptGameController.GameOver != true && scriptGameEvent.AccessSpawnMinions != true && gracePeriodLockOut != true)
                    // Check to see if it is time to spawn another minion
                    if (Time.time >= nextSpawn)
                        SpawnSignal();
                // ----

                // Brief wait time to ease the CPU
                yield return new WaitForSeconds(0.1f);
            } // While()
        } // SpawnController()



        // Determine how long the minions will spawn within the given time of 60 seconds.
        private float MinionsASecond()
        {
            return 60 / spawnRate;
        } // MinionASecond()



        // Determine the new time in which a new minion will be spawned in the scene
        private void CalcNextSpawnTime()
        {
            float r = Random.Range(0, 2 * MinionsASecond());
            nextSpawn = Time.time + r;
        } // CalcNextSpawnTime()



        // Send a signal to spawn the creature
        private void SpawnSignal()
        {
            // Broadcast a signal to the spawners to summon a minion.
                EnableSpawnPoint();
            // Determine the next time to summon a new minion creature
                CalcNextSpawnTime();
        } // SpawnSignal()



        // This function will kindly tell delay the signal to start instantiating the minions.
        public void GracePeriodTimeOut_Request()
        {
            gracePeriodLockOut = true;
        } // GracePeriodTimeOut_Request()



        // This function initiate the grace timer - that will momentarily delay the spawners from ever being activated.
        private void GraceTimer()
        {
            // A simple timer
                StartCoroutine(GraceTimer_InitiateTimer());
        } // GraceTimer()



        // The Timer function will disallow the spawners from becoming active until the wait-delay has passed.
        private IEnumerator GraceTimer_InitiateTimer()
        {
            gracePeriodLockOut = true;
            yield return new WaitForSeconds(gracePeriodTimer);
            gracePeriodLockOut = false ;
        } //GraceTimer_InitiateTimer()



        // This function will check to make sure that all the references has been initialized properly.
        private void CheckReferences()
        {
            if (scriptGameController == null)
                MissingReferenceError("Game Controller");
            if (scriptGameEvent == null)
                MissingReferenceError("Game Event");
        } // CheckReferences()



        // When a reference has not been properly initialized, this function will display the message within the console and stop the game.
        private void MissingReferenceError(string refLink = "UNKNOWN_REFERENCE_NOT_DEFINED")
        {
            Debug.LogError("Critical Error: Could not find a reference to [ " + refLink + " ]!");
            Debug.LogError("  Can not continue further execution until the internal issues has been resolved!");
            Time.timeScale = 0; // Halt the game
        } // MissingReferenceError()
    } // End of Class
} // Namespace