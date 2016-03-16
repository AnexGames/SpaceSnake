using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour {
	
	public GFGrid grid;
	private Transform cachedTransform;
	
	public static bool deadTrigger;
	
	// Use this for initialization
	void Start() {
		
		cachedTransform = this.transform;
	
		grid.AlignTransform(cachedTransform, false);
	
	
			
	}
	

	

	
	void OnTriggerEnter(Collider col){
		
		if(col.gameObject.tag == "Player"){
			if(Zone1.isTriggered == false && Zone2.isTriggered == false && Zone3.isTriggered == false && Zone4.isTriggered == false){
				PlayerMovement.playAudio = true;
				PlayerPref_HighScore.SetHighScore();
				PlayerMovement.isDead = true;
				//Destroy(GameObject.Find("Snake Head"));
			
				}
			
			else if(Zone1.isTriggered == true || Zone2.isTriggered == true || Zone3.isTriggered == true || Zone4.isTriggered == true){
				deadTrigger = true;
				Zone1.timerGoing = false;
				Zone2.timerGoing = false;
				Zone3.timerGoing = false;
				Zone4.timerGoing = false;
				
				PlayerMovement.isTeleported = true;
				PlayerMovement.snakeHead.transform.position = Zone1.spawnPoint_1.transform.position;	
			}
			
//			 if(RedCoinTrigger.zoneTriggered == false && RedCoin2.zoneTriggered2 == false && RedCoin3.zoneTriggered3 == false && RedCoin4.zoneTriggered4 == false){
//				PlayerPref_HighScore.SetHighScore();
//				PlayerMovement.isDead = true;
//				Destroy(GameObject.Find("Snake Head"));
//			}
//			
//			else if(RedCoinTrigger.zoneTriggered == true || RedCoin2.zoneTriggered2 == true || RedCoin3.zoneTriggered3 == true || RedCoin4.zoneTriggered4 == true){
//				deadTrigger = true;
//				RedCoinTrigger.timerGoing = false;
//				RedCoin2.timerGoing = false;
//				RedCoin3.timerGoing = false;
//				RedCoin4.timerGoing = false;
//				
//				PlayerMovement.isTeleported = true;
//				PlayerMovement.snakeHead.transform.position = RedCoinTrigger._spawnPoint.transform.position;	
//				
//			}
			
		}
	
	}
}
