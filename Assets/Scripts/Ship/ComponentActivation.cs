﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ComponentActivation : MonoBehaviour 
{
    // Declarations and Initializations
    // ---------------------------------
    // Speed that is used when the minions are climbing the ladder
        private float climbSpeed;
    // Speed that is used when the minions are walking (or running) forward
        private float walkSpeed;
    // Force 'thrust' that is used when the minions have been selected.
        public float force = 1000f;
    // Minion actions:
        private bool isClimbing = false;
        private bool isWalking = true;
    // Direction in which the Minions are thrusted
        private Vector3 forceDirection;
    // Script reference link
        private CreatureIdentity id;

    // Multimedia
    // --
        // Screeches
            public AudioClip screechOne;
            public AudioClip screechTwo;
            public AudioClip screechThree;
            public AudioClip screechFour;
	        public AudioClip screechFive;
	        public AudioClip screechSix;
        // Won
	        public AudioClip celebrationOne;
	        public AudioClip celebrationTwo;

    // Animations and physics
        private Animator minionAnim;
        private CapsuleCollider capsuleCollider;
    // ----
	


	void Awake() 
	{
        // References
            minionAnim = GetComponent<Animator>();
            capsuleCollider = GetComponent<CapsuleCollider>();
	} // End of Awake



	void Start()
	{
        // Force direction that will be used for eliminating the minion
            forceDirection = new Vector3(1f, 1f, 0);
        // Self-Randomize the speed
            climbSpeed = Random.Range(9.89f, 13.12f);
            walkSpeed = Random.Range(3.98f, 6.5f); 
	} // End of Start
	


    // When the minions 'hit' with other objects, this function is going to be called.
	void OnTriggerEnter(Collider other)
	{
        // Ladder collision:
		if(other.tag == "Ladder")
		{
            //id = gameObject.GetComponent<CreatureIdentity>();
            //Debug.Log("Hit Ladder: " + id.Number.ToString());
            // ----
            isClimbing = true;
            isWalking = false;
			minionAnim.SetTrigger ("Climb");
		} // End if (ladder)

        // Forward Enabler (game object) collision:
        else if (other.tag == "ForwardEnabler")
		{
            //id = gameObject.GetComponent<CreatureIdentity>();
            //Debug.Log("Hit Forward Enabler: " + id.Number.ToString());
            // ----
            isClimbing = false;
            isWalking = true;
			minionAnim.SetTrigger ("Walk");
        } // End if (ForwardEnabler)

        // Exit collision:
        else if (other.tag == "exit")
		{
            //id = gameObject.GetComponent<CreatureIdentity>();
            //Debug.Log("Hit Exit: " + id.Number.ToString());
            // ----
			// exit code
        } // End if (exit)

        // Minion collision (colliding with another minion):
        else if (other.tag == "Minion")
        {
            // Temp Debug Messages [NG]
            Debug.Log("Hit with minion detected");
        } // End if (Minion)

        // Temp Debug Messages [NG]
        Debug.Log("Minion has hit tag: " + other.tag);

	} // End of OnTriggerEnter



    // This function is called when the minions are going to walk.
    void Walk()
    {
        transform.Translate(new Vector3(0, 0, 1) * walkSpeed * Time.deltaTime);
    } // End of Walk



    // This functions is called when the minions are going to climb
    void Climb()
    {
        transform.Translate(new Vector3(0, 1, 0) * climbSpeed * Time.deltaTime);
    } // End of Climb
    


    // Update on every frame
    void Update()
    {
        // Check to see if the minion needs to walk or climb
        if(isWalking == true)
        {
            Walk();
        }
        else if (isClimbing == true)
        {
            Climb();
        }

    } // End of Update



    // When the creature has been 'selected', this function will be called
    void OnMouseDown()
    {
		// Created a method for all of these below______________________DAVID
		/*
        rigidbody.useGravity = true;
        rigidbody.isKinematic = false;
        rigidbody.AddForce(forceDirection * force);
        Debug.Log("Clicked!");
        Destroy(gameObject, 1f);
        minionAnim.SetBool ("isFlicked", true);
		Destroy(capsuleCollider);
		*/
		Flick ();
		MinionSqueal();
    } // End of OnMouseDown



    // Actions to take place when the minion has been selected
	public void Flick()
	{
		rigidbody.useGravity = true;
		rigidbody.isKinematic = false;
		isClimbing = false;
		rigidbody.AddForce(forceDirection * force);
		Debug.Log("Clicked!");
		Destroy(gameObject, 1f);
		minionAnim.SetBool ("isFlicked", true);
		Destroy(capsuleCollider);
	} // End of Flick



    // Sounds from the minion when selected
    public void MinionSqueal()
	{	
        int sound = Random.Range (1, 7);
		switch (sound)
		{
		case 1:
			audio.clip = screechOne;
			print("Audio 1 was played.");
			break;
		case 2:
			audio.clip = screechTwo;
			print("Audio 2 was played.");
			break;
		case 3:
			audio.clip = screechThree;
			print("Audio 3 was played.");
			break;
		case 5: 
			audio.clip = screechFive;
			print ("Audio five was played.");
			break;
		case 6:
			audio.clip = screechSix;
			print("Audio six was played.");
			break;
		default:
			audio.clip = screechFour;
			print("Audio 4 was played.");
			break;
		} // End switch
        
        audio.Play();

    } // End of MinionSqueal

} // End of Class
