﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class PlayerSet : MonoBehaviour {

	public float radius = 1f;
	public GameObject center;

	public int sizeOfSet;

	//list store numbers
	public List<int> playerSet1 = new List<int>();
	//depending on the values in set1, generate corresponding elements in set2
	public List<GameObject> playerSet2 = new List<GameObject> ();

	public bool on_first_island;
	public bool on_second_island;
	public bool on_third_island;
	bool fresh_start;

	//GameObject follower = new GameObject();

	void Start () {
		fresh_start = true;
		on_first_island = true;
		on_second_island = false;
		on_third_island = false;

		//Application.LoadLevel(1);




		/*RANDOM ALGORITHM
		//set the size of the set
		//the size of this set is from 0 to 7
		sizeOfSet = Random.Range (0, 7);
		//generate unique random numbers for the set
		//you can have empty set
		for(int i = 0; i < sizeOfSet; i++)
		{
			//the random int generated has 7 options
			int randomInt = Random.Range (0,6);
			while(playerSet1.Contains(randomInt))
			{
				randomInt = Random.Range (0,6);
			}
			playerSet1.Add (randomInt);
			//Instantiate(ele,follower.transform.position,follower.transform.rotation);
		}
		*/

		//add corresponding elements to set2


	}

	void OnTriggerEnter (Collider other)
	{
		
		
		if (other.tag == "2nd_trigger") {
			Debug.Log ("touch trigger");
			on_first_island = false;
			on_second_island = true;
			on_third_island = false;
			fresh_start = true;
		}
		if (other.tag == "3rd_trigger") {
			on_first_island = false;
			on_second_island = false;
			on_third_island = true;
			fresh_start = true;
		}
	}

	// Update is called once per frame
	void Update () {
		center.transform.position = transform.position;

		if(fresh_start == true){
			GameObject e0 = GameObject.Find ("ball_01");
			GameObject e1 = GameObject.Find ("ball_02");
			GameObject e2 = GameObject.Find ("ball_03");
			GameObject e3 = GameObject.Find ("ball_04");
			GameObject e4 = GameObject.Find ("ball_05");
			GameObject e5 = GameObject.Find ("ball_06");
			GameObject e6 = GameObject.Find ("ball_07");
		//if on 1st island
			if (on_first_island == true) {
			//p set = {1,3}
				playerSet1.Clear();
				sizeOfSet = 2;
				playerSet1.Add (1);
				playerSet1.Add (3);
				foreach (Transform child in center.transform) {
					GameObject.Destroy(child.gameObject);
				}
			}
		//if on 2nd island
			if(on_second_island == true){
			//p set = {};
				playerSet1.Clear();
				playerSet2.Clear();
				foreach (Transform child in center.transform) {
					GameObject.Destroy(child.gameObject);
				}
				sizeOfSet = 0;

			}
		//if on 3rd island
			if(on_third_island == true){
			//p set = {0};
				playerSet1.Clear();
				playerSet2.Clear();
				sizeOfSet = 1;
				playerSet1.Add (0);
			}
			for(int i = 0;i<sizeOfSet;i++)
			{
				int choice = playerSet1[i];
				switch(choice)
				{
				case 0:
					playerSet2.Add (e0);
					break;
				case 1:
					playerSet2.Add (e1);
					break;
				case 2:
					playerSet2.Add (e2);
					break;
				case 3:
					playerSet2.Add (e3);
					break;
				case 4:
					playerSet2.Add (e4);
					break;
				case 5:
					playerSet2.Add (e5);
					break;
				case 6:
					playerSet2.Add (e6);
					break;
					
				}
				
			}
			
			for (int i = 0; i < sizeOfSet; i++) {
				//instantiate elements in set2 at some random position
				
				//playerSet2[i] = (GameObject) Instantiate (playerSet2[i],new Vector3 (i,i,0),transform.rotation);
				playerSet2[i] = (GameObject)Instantiate (playerSet2[i],new Vector3 (i,i,0),Quaternion.Euler(new Vector3(45, 0, 0)));
				
				float angle = i * Mathf.PI * 2 / sizeOfSet;
				Vector3 pos = new Vector3(Mathf.Cos(angle), 0.5f, Mathf.Sin(angle)) * radius + center.transform.position ;
				playerSet2[i].transform.position = pos;
				playerSet2[i].transform.parent = center.transform;
				
			}
			//after instantiation, make sure this instantiate only occur once
			fresh_start = false;
		}


	}
}
