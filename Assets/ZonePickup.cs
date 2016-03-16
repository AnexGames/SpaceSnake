using UnityEngine;
using System.Collections;

public class ZonePickup : MonoBehaviour {

	public GFGrid grid;
	private Transform cachedTransform;
	
	public AudioClip aClip;
	
	//red coin
	public float time;
	public float maxInterval = 1.2f;
	public float minInterval = 0.2f;
	
	private float interval = 1.0f;
	public float timer = 30.0f;
	
	// Use this for initialization
	void Start() {
		
		cachedTransform = this.transform;
	
		grid.AlignTransform(cachedTransform, false);
		
		timer = time;
	}
	
	
	// Update is called once per frame
	void Update () {
//		if(RedCoinTrigger.timerGoing == true){
			//Debug.Log("TIMER IS GOING!");
		 	interval = minInterval + timer / time * (maxInterval - minInterval);
			timer -= Time.deltaTime;
			
			if(timer < 0.0f) time = 0.0f;
			GetComponent<Renderer>().enabled = Mathf.PingPong(Time.time, interval) > (interval / 2.0f);
//		}
	}
	

	void OnTriggerEnter(Collider col){
		
		if(col.gameObject.tag == "Player"){

            GetComponent<AudioSource>().PlayOneShot(aClip);
			GetComponent<Renderer>().enabled = false;
			GameManager.zoneGoal += 1;
			Debug.Log(GameManager.zoneGoal);
			Debug.Log("You've picked up Red Coin");
			
			Destroy(this.gameObject, aClip.length);
			
		}
	}
}
