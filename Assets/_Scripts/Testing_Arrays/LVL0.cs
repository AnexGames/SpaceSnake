using UnityEngine;
using System.Collections;

public class LVL0 : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		hoMove move = gameObject.GetComponent<hoMove>();
		if(score.foodPickedTotal >= 2){
			move.Resume();
		}
	
	}
	
	void Goal1(){
		hoMove move = gameObject.GetComponent<hoMove>();
		
		move.Pause();
	}
			
}
