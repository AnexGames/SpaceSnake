using UnityEngine;
using System.Collections;

public class laser : MonoBehaviour {


	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player"){
			
			PlayerMovement.isDead = true;
			
		}
	}
}
