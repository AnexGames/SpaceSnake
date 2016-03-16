using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class Zone1 : MonoBehaviour {
	
	public float timer = 15.0f;
	public static bool timerGoing;
	
	public List<GameObject> bonusPickup = new List<GameObject>();
	
	public static int bonusCount = 0;
	public static bool isTriggered; 
	public static GameObject spawnPoint_1;

	public AudioClip powerup;
	// Use this for initialization
	void Start () {
		
		isTriggered = false;
		foreach(Transform child in transform){
			
			bonusPickup.Add(child.gameObject);
		}
		
		bonusCount = bonusPickup.Count;
		
		
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
			
			//if(bonusCount <= 0 && CanCamMove.inReach == true){
			if(bonusCount <= 0){
                GetComponent<AudioSource>().Play();
				FinalMazePickup.mazeTrigger = true;
				ScoreMultiplier.multiplier += 1.0f;
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
	
	void OnTriggerEnter(Collider col) { 
		
		if(col.gameObject.tag == "Player"){
			spawnPoint_1 = GameObject.FindGameObjectWithTag("SpawnPoint");
			isTriggered = true;	
			StartCoroutine(MazeEntered());
			Debug.Log("TIMER STARTED");
		}
	}
}
