﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Instantiate_elements_in_a_circle_player_after : MonoBehaviour {
	public GameObject center;
	public float radius = 1f;
	//public float rotate_speed = 5.0f;
	
	List<GameObject> elements_in_samurai_after = new List<GameObject>();
	
	//elements_in_samurai_after list contains 
	//air
	//fire
	//gold
	//soil
	//water
	//wind
	//wood
	void Start() {
		GameObject e1 = GameObject.Find ("air");
		GameObject e2 = GameObject.Find ("fire");
		GameObject e3 = GameObject.Find ("gold");
		GameObject e4 = GameObject.Find ("soil");
		GameObject e5 = GameObject.Find ("water");
		GameObject e6 = GameObject.Find ("wind");
		GameObject e7 = GameObject.Find ("wood");

		elements_in_samurai_after.Add (e1);
		elements_in_samurai_after.Add (e2);
		elements_in_samurai_after.Add (e3);
		elements_in_samurai_after.Add (e4);
		elements_in_samurai_after.Add (e5);
		elements_in_samurai_after.Add (e6);
		elements_in_samurai_after.Add (e7);

		for (int i = 0; i < elements_in_samurai_after.Count; i++){
			Vector3 pos = new Vector3 (i,i,0);
			
			elements_in_samurai_after[i] = (GameObject)Instantiate(elements_in_samurai_after[i],pos, transform.rotation);
			
		}

		for (int i = 0; i < elements_in_samurai_after.Count; i++) {
			float angle = i * Mathf.PI * 2 / elements_in_samurai_after.Count;
			Vector3 pos = (new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), -10)* radius)+center.transform.position;
			elements_in_samurai_after[i].transform.position = pos;
			elements_in_samurai_after[i].transform.parent = GameObject.Find ("playerElementsAfter").transform;

		}
	}
	
	// Update is called once per frame
	void Update () {
		
		//transform.Rotate (new Vector3 (0, 0, 15)*Time.deltaTime*rotate_speed);
	}
}