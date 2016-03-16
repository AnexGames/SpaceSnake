using UnityEngine;
using System.Collections;

public class ButtonTest_right : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick(){
		PlayerMovement.nextDir = new Vector3(1,0,0);	
	}
}
