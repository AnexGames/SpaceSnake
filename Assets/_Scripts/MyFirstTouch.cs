using UnityEngine;
using System.Collections;

public class MyFirstTouch : MonoBehaviour {

	// Subscribe to events
// Subscribe to events
	void OnEnable(){
	EasyTouch.On_TouchStart += On_TouchStart;
	}
	// Unsubscribe
	void OnDisable(){
	EasyTouch.On_TouchStart -= On_TouchStart;
	}
	// Unsubscribe
	void OnDestroy(){
	EasyTouch.On_TouchStart -= On_TouchStart;
	}
//	// At the touch beginning
	public void On_TouchStart(Gesture gesture){
		Debug.Log("You touched");
	}
	}

