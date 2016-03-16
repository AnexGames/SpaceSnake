using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TweenAlpha ta = TweenAlpha.Begin(this.gameObject,1,1);
		
		ta.eventReceiver = this.gameObject;
		ta.callWhenFinished = "LoadLevel";
		
		
	}
	
	void LoadLevel(){
		Application.LoadLevel(2);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
