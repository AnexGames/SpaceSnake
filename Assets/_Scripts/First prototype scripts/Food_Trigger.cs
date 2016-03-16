using UnityEngine;
using System.Collections;

public class Food_Trigger : MonoBehaviour {
	
	public GFGrid grid;
	public Transform cachedTransform;
	public GameObject helper;
	
	
	void Start(){ 
		//GFGrid.FindObjectOfType("GFGrid");
		
		cachedTransform = transform;
		
		if(grid){
			grid.AlignTransform(cachedTransform);
		}
	}
	
	
	// If player collides when food
	// Pick up and instantiate a new food object at random location
	void OnTriggerEnter(Collider col){
		
		//Vector3 position = new Vector3(Random.Range(-18.3f,18.6f), Random.Range (-13.0f, 14.0f), -0.6f);
		if(col.gameObject.tag == "Player"){
			
			//Add 100 to score by calling variable through MainGUI script
			int score_1 = MainGUI.score += 100;
			
			//NEEDS WORK - if player score is above 300 player movement speed is increased
			if (score_1 == 300){
				//PlayerMovement.playerSpeed = 3.0f;
			}
			
			
			Instantiate(helper);
			Destroy(gameObject);

				
		}
	}
}
