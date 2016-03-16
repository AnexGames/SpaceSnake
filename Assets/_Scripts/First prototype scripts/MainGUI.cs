using UnityEngine;
using System.Collections;

public class MainGUI : MonoBehaviour {
	
	static public int score = 0;
	static public int lives = 3;
	
	void OnGUI(){
		//create score label
		GUI.Label (new Rect (800, 25, 100, 100), "Score: " + score);
		
		//create lives label 
		GUI.Label (new Rect (25, 25, 500, 100), "Lives: " + lives);
		
		//create play again button if player runs out of lives
		if (lives <= 0){
			//set isDead variable to true to pause movement 
			PlayerMovement.isDead = true;
		}
		
		
		//if player has ran out of lives give the option to play again and restart
		if(PlayerMovement.isDead){
			if (GUI.Button(new Rect(400,175 ,100,50),"Play Again?"))
				
				//Time.timeScale = 1;
				//pause the game wait for player 
				Application.LoadLevel(Application.loadedLevel);
				
				
				//Reset score and lives 
				lives = 3;
				score = 0;
				//PlayerMovement.playerSpeed = 30.0f;
		}
	}
	
	
}
