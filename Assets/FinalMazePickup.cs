using UnityEngine;
using System.Collections;

public class FinalMazePickup : MonoBehaviour {

	public GFGrid grid;
	private Transform cachedTransform;
	public GameObject spawnPoint;
	public static bool mazeTrigger;
	public AudioClip audio;
	public static int goal = 0;
	
	// Use this for initialization
	void Start() {
		
		cachedTransform = this.transform;
	
		grid.AlignTransform(cachedTransform, false);
	

	}
	

	void OnTriggerEnter(Collider col){
		
		if(col.gameObject.tag == "Player"){
			
			goal += 1;
			Debug.Log(goal);
			if(goal == 3){
				
				mazeTrigger = true;
			}
			
			Destroy(this.gameObject.GetComponent<TweenRotation>());
			
			this.gameObject.GetComponent<Renderer>().material.color = Color.green;
			this.gameObject.GetComponent<Light>().color = Color.green;

			if(audio)
				AudioSource.PlayClipAtPoint(audio, transform.position);
			
		}
	}
}
