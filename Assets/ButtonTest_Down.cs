using UnityEngine;
using System.Collections;

public class ButtonTest_Down : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick(){
		PlayerMovement.nextDir = new Vector3(0,-1,0);	
	}
}
