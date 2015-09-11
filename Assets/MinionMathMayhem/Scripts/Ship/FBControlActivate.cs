﻿// This script will be attached to the fb_control object and allow the Feedback
// canvas to activate its animation

using UnityEngine;
using System.Collections;

namespace MinionMathMayhem_Ship
{
	public class FBControlActivate : MonoBehaviour {

		// 'fb_control' gameObject's animator component
		private Animator controlAnim;

		void Awake()
		{
			// initialize animator
			controlAnim = GetComponent<Animator>();
		}

		// Plays the animation on the control object by setting the trigger in the animator for the fb_control
		private void PlayControlAnimation()
		{
			controlAnim.SetTrigger ("Push");
		}

		// Accessor for FeedbackAnimations to call PlayControlAnimation()
		public void PlayControlAnim()
		{
			PlayControlAnimation ();
		}


		
	} // End class
} // End namespace