﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class Zone2 : MonoBehaviour {
	
	public float timer = 15.0f;
	public static bool timerGoing;
	private bool GatherFood;
	public List<GameObject> bonusPickup = new List<GameObject>();
	
	public static int bonusCount2 = 0;
	public static bool isTriggered; 
	// Use this for initialization
	void Start () {
		
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(timerGoing == true){
			timer -= Time.deltaTime;
		}
	
	}
	
	public IEnumerator MazeEntered () {
		timerGoing = true;	
		
		while(timerGoing == true){
			yield return null;
			
		
			if(bonusCount2 <= 0){
                GetComponent<AudioSource>().Play();
				FinalMazePickup.mazeTrigger = true;
				ScoreMultiplier.multiplier += 2.0f;
				Debug.Log("Timer DONE!");
				yield return new WaitForSeconds(1.0f);
				FinalMazePickup.mazeTrigger = false;
				timerGoing = false;
			
			}
		
			else if(timer <=0){
				FinalMazePickup.mazeTrigger = true;
				Debug.Log("Timer DONE!");
				yield return new WaitForSeconds(1.0f);
				FinalMazePickup.mazeTrigger = false;
				timerGoing = false;
			}
			
			else if(Barrier.deadTrigger == true){
				FinalMazePickup.mazeTrigger = true;
				Debug.Log("You died in zone, Telport to nearest level");
				yield return new WaitForSeconds(1.0f);
				//FinalMazePickup.mazeTrigger = false;
				timerGoing = false;
			}
			
		}
		
	}
	
	void GatherZoneFood(){
		foreach(Transform child in transform){
			
			bonusPickup.Add(child.gameObject);
		}
		
		bonusCount2 = bonusPickup.Count;
	}
	
	void OnTriggerEnter(Collider col) { 
		
		if(col.gameObject.tag == "Player"){
			Zone1.spawnPoint_1 = GameObject.FindGameObjectWithTag("SpawnPoint2");
			isTriggered = true;
			GatherZoneFood();	
			StartCoroutine(MazeEntered());
			Debug.Log("TIMER STARTED");
		}
	}
}