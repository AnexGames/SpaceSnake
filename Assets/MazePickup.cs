using UnityEngine;
using System.Collections;

public class MazePickup : MonoBehaviour {
	
	public GFGrid grid;
	private Transform cachedTransform;
	public GameObject spawnPoint;
	
	public GameObject _l;
	// Use this for initialization
	void Start() {
		
		cachedTransform = this.transform;
	
		grid.AlignTransform(cachedTransform, false);
	
	
			
	}
//	
//	void Update(){
//		if(PlayerMovement.isTeleported == false){
//		NGUITools.SetActive(_l, false);	
//		}
//	}
//	
//	void ChooseDirectionLabel(){
//		while(PlayerMovement.isTeleported == true){
//			NGUITools.SetActive(_l, true);	
//		}
//	}

	void OnTriggerEnter(Collider col){
		
		if(col.gameObject.tag == "Player"){
//			Vector3 size = this.transform.localScale;
//			
//			_l.transform.position = size;
			PlayerMovement.isTeleported = true;
//			ChooseDirectionLabel();
			PlayerMovement.snakeHead.transform.position = spawnPoint.transform.position;
			
		}
	}
	

}
