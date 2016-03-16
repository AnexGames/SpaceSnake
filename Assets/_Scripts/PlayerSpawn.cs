using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {
	
	public static GameObject player;

	
	// This is function is going to spawn a new player after death
	public static void SpawnPlayer(){
		PlayerMovement.isDead = false;
		//Call the snake head through the resource folder in the project panel
		GameObject playerPrefab = (GameObject)Instantiate(Resources.Load("Snake Head"));
		playerPrefab.GetComponent<PlayerMovement>().enabled = true;
		
//		PlayerMovement.playerSpeed = 30.0f;
		//change name of the player clone
		playerPrefab.name = ("Snake Head");
		
		//reduce the life by 1
		//MainGUI.lives -= 1;
		
		
	}
}
