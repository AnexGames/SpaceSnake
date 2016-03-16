using UnityEngine;
using System.Collections;

public class Press_To_Start : MonoBehaviour {
	public GameObject space_Start;
	
	void Awake() { 
		Time.timeScale = 0;
		PlayerMovement.canJump = false;
		PlayerMovement.startTimer = false;
	}
	
	// Use this for initialization
	void Start () {
		NGUITools.SetActive(space_Start, true);
		
	}

	// Update is called once per frame
	void Update () {
		
		
		if(Input.GetKey("space")){
			Time.timeScale = 1;
			NGUITools.SetActive(space_Start, false);
			PlayerMovement.canJump = true;
			PlayerMovement.startTimer = true;
			Destroy(this);
		}
	
	}
	//Suscribe to events	
	void OnEnable(){
		EasyTouch.On_TouchStart+= On_TouchStart;
		
	}
	// Unsubscribe
	void OnDisable(){
		EasyTouch.On_TouchStart -= On_TouchStart;
		
	}
	// Unsubscribe
	void OnDestroy(){
		EasyTouch.On_TouchStart -= On_TouchStart;
		
	}
	// At the touch beginning
	public void On_TouchStart(Gesture gesture){
		Time.timeScale = 1;
		NGUITools.SetActive(space_Start, false);
	}
}
