using UnityEngine;
using System.Collections;

public class OutsideBarrier : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		
		if(col.gameObject.tag == "Player"){
			Destroy(GameObject.Find("Snake Head"));
			PlayerMovement.isDead = true;
				}
	}
}
