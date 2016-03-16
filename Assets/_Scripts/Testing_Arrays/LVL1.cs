using UnityEngine;
using System.Collections;

public class LVL1 : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		hoMove move1 = gameObject.GetComponent<hoMove>();
	}
	
	// Update is called once per frame
	void Update () {
			hoMove move1 = gameObject.GetComponent<hoMove>();
		if(score.foodPickedTotal >= 2){
			move1.Resume ();
		}
	}
	
	void Goal1(){
		hoMove move1 = gameObject.GetComponent<hoMove>();
//		if (score.foodPickedTotal >= 10){
//			
//			
//			
//			move1.Resume();
//			
//		}
//		else{
			move1.Pause();
		
	}
}
