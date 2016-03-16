using UnityEngine;
using System.Collections;

public class RedCoin2 : MonoBehaviour {
	
	public GFGrid grid;
	private Transform cachedTransform;
	
	public static bool zoneTriggered2;
	private Color currentColor;
	
	public float zoneTimer = 30f;
	public static bool timerGoing;
	
	public float waitTime = 0.2f;
	public float timer;
	public float resetPoint;
	
	private GameObject[] redCoins;
	private bool alreadyChecked;
	
	// Use this for initialization
	void Start() {
		
		redCoins = GameObject.FindGameObjectsWithTag("RedCoin2");
		resetPoint = waitTime * 2;
		
		cachedTransform = this.transform;
	
		grid.AlignTransform(cachedTransform, false);
	
	
			
	}
	
	// Update is called once per frame
	void Update () {
		if(alreadyChecked == false){ 
			if(zoneTriggered2 == false){
				//Disable all red coin pickups until activated by trigger
				foreach(GameObject i in redCoins){
					i.active = false;
				}
				
	
			}
		}
	
		if(timerGoing == true){
			zoneTimer -= Time.deltaTime;
		}
		
	}
	
	public IEnumerator ZoneEntered () {
		timerGoing = true;	
		
		while(timerGoing == true){
			yield return null;
	
			 if(zoneTimer <=0){
				GameManager.zoneGoal = 0;
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
				alreadyChecked = true;
				timerGoing = false;
				zoneTriggered2 = false;
			}
		}
		
	}
	
	void OnTriggerEnter(Collider col){
		
		if(col.gameObject.tag == "Player"){
			RedCoinTrigger._spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint2");
			grid.transform.position = new Vector3(0, 78, 0);
			grid.size = new Vector3(12, 10 , 0);

            GetComponent<AudioSource>().Play();
			GameManager.zoneGoal = 0;
			
			foreach(GameObject i in redCoins){
				i.active = true;
			}
			zoneTriggered2 = true;
			StartCoroutine(ZoneEntered ());
			this.gameObject.GetComponent<Collider>().enabled = false;
			
		}
	}
}
