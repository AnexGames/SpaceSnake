using UnityEngine;
using System.Collections;

public class CanCamMove : MonoBehaviour {
	public static bool inReach;
	
	void OnTriggerEnter(Collider col){
		
		if(col.gameObject.tag == "Player")
			inReach = true;
	}
	
	void OnTriggerExit(){
		inReach = false;	
	}
}
