using UnityEngine;
using System.Collections;

public class RedCoinTrigger : MonoBehaviour {
	//Grid Snap
	public GFGrid grid;
	private Transform cachedTransform;
	
	public float zoneTimer = 30f;
	public static bool timerGoing;
	public static bool zoneTriggered;
	private Color currentColor;
	
	public float waitTime = 0.2f;
	public float timer;
	public float resetPoint;
	public static GameObject _spawnPoint;
	private GameObject[] redCoins;
	private bool alreadyChecked;

	
	// Use this for initialization
	void Start() {
		
		redCoins = GameObject.FindGameObjectsWithTag("RedCoin");
		resetPoint = waitTime * 2;
		
		cachedTransform = this.transform;
	
		grid.AlignTransform(cachedTransform, false);
			
	}
	
	// Update is called once per frame
	void Update () {
		 
		if(alreadyChecked == false){
			if(zoneTriggered == false){
				//Disable all red coin pickups until activated by trigger
				foreach(GameObject i in redCoins){
					i.active = false;
				}
			}
		}
		
		if(timerGoing == true){
			zoneTimer -= Time.deltaTime;
		}
			
//			timer += Time.deltaTime;
//			
//			if(timer < waitTime){
//				GetComponent<Renderer>().material.color = Color.white;
//				
//			}
//			
//			if(timer > waitTime){
//				GetComponent<Renderer>().material.color = Color.green;
//				
//			}
//			
//			if(timer > resetPoint){
//				timer = 0;
//			}
//		}
//	
//	if(zoneTriggered == true){
//			GetComponent<Renderer>().material.color = Color.green;
//			
//			
//		}
		
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
				zoneTriggered = false;
			}
		}
		
	}
	
	void OnTriggerEnter(Collider col){
		
		if(col.gameObject.tag == "Player"){
			_spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
			grid.transform.position = new Vector3(0, 39, 0);
			grid.size = new Vector3(11, 9 , 0);

            GetComponent<AudioSource>().Play();
			GameManager.zoneGoal = 0;
			
			foreach(GameObject i in redCoins){
				i.active = true;
			}
			zoneTriggered = true;
			StartCoroutine(ZoneEntered ());
			this.gameObject.GetComponent<Collider>().enabled = false;

			
		}
	}
	
}
