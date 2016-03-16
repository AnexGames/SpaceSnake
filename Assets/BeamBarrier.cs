using UnityEngine;
using System.Collections;

public class BeamBarrier : MonoBehaviour {
	GameObject[] _lasers;

	// Use this for initialization
	void Start () {
		_lasers = GameObject.FindGameObjectsWithTag("_laser");

	}
	
	// Update is called once per frame
	void Update () {
		
		if(FinalMazePickup.mazeTrigger == true || GameManager.foodPickedTotal >= 10 || GameManager.zoneGoal >= 8){
			StartCoroutine(BarrierOff());	
		}
	}
	
	public IEnumerator BarrierOff(){
        this.GetComponent<Collider>().enabled = false;
		//this.gameObject.collider.enabled = false;
		foreach(GameObject barrier in _lasers){
			barrier.SetActive(false);	
		}

		yield return new WaitForSeconds(5.0f);
		
		foreach(GameObject barrier in _lasers){
			barrier.SetActive(true);	
		}
        this.GetComponent<Collider>().enabled = true;

    }
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			PlayerMovement.playAudio = true;
			PlayerMovement.isDead = true;	
		}
	}
}
