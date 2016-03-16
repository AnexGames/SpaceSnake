using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeMovement : MonoBehaviour {
	
	//Grid reference for snapping attached object
	public GFRectGrid myGrid; 
	public Transform cached;
	
	//Create our snake list that holds head and body objects
	public List <GameObject> snakeUpdate = new List<GameObject>();
	
	//prefab for our snake body object
	public GameObject snakeBody;
	
	//var for timer to control movement tick
	public float tickTime = 1f;
	private float sinceLastTick = 0f;
	
	//Vector 3 that stores our input 
	private Vector3 direction;
	
	//Is player dead? Paused? .....cmon 
	private bool isPaused;
	private bool isDead;
	
	//bool Inputs ... name says it all 
	private bool left;
	private bool right;
	private bool up;
	private bool down;
	
	// Use this for initialization
	void Start() {
		
		isDead = false;
		
		//set our transform var to this transform
		cached = this.transform;
		
		//align snake head to grid
		if(myGrid)
			myGrid.AlignTransform(cached);
			
		SpawnSnakeBody();
	
	}
	
	// Update is called once per frame
	void Update() {
		
		if(!isDead){
			
			sinceLastTick += Time.deltaTime;
			
			//My tick timer that updates position of snake
			if(sinceLastTick > tickTime){
					
				HeadMovement();
				DrawSnake();	
				
				cached.position += direction;
				
				GameManager.totalScore += 1;
				sinceLastTick -= tickTime;
			}
		}
	}
					
		
	//Keeps track of user input and stores vector 3 in 'direction' var
	private void HeadMovement() { 
		
		if(Input.GetKey("up") && !down) {
			up = true;
			down = false;
			left = false;
			right = false;
			
			score.movesToFood += 1;
			
			//This is where we store our vector3 to get called each tick
			direction = myGrid.up;
					
		}
		
		else if( Input.GetKey ("down") && !up){
			up = false;
			down = true;
			left = false;
			right = false;
				
			score.movesToFood += 1;	
				
			direction = -myGrid.up;
		
		}
		
		else if(Input.GetKey ("left") && !right ){
			up = false;
			down = false;
			left = true;
			right = false;
				
			score.movesToFood += 1;
				
			direction = -myGrid.right;
		
		}
		
		else if(Input.GetKey ("right") && !left){
			up = false;
			down = false;
			left = false;
			right = true;
				
			score.movesToFood += 1;
				
			direction = myGrid.right;
	
		}
	}
	
	//Method to draw each snake and update position
	private void DrawSnake() {
		
		//for every object in list 
		for (int i = (snakeUpdate.Count - 1); i > 0; i--){
			
			//give that object the position of object in front
			snakeUpdate[i].transform.position = snakeUpdate[i-1].transform.position;
			
			
		}
	}
	
	//This will spawn the 3 snake body objects at start of game
	private void SpawnSnakeBody() {
		
		//Add head object to list at 0 position
		snakeUpdate.Add(this.gameObject);
		
		//Add 3 body pieces at start of the game
		for(int i = 0; i < 3  ; i++){
			
			//I'm instantiating 3 body objects at the start of the game off the screen.
			GameObject h = Instantiate(snakeBody, new Vector3(100,100,100), transform.rotation)as GameObject;
			
			//Add objects to list
			snakeUpdate.Add(h);
		}
	}
	
	//Teleport function to call when player has gone through teleport object. 
	private void TeleportSnake(GameObject teleport, int x, int y){
		
		for (int i = 0; i < snakeUpdate.Count; i++){
			
			//Take snake head and give it a new vector3 of teleport object with a given direction
			snakeUpdate[0].transform.position = new Vector3(teleport.transform.position.x + x, 
				teleport.transform.position.y + y,
				this.gameObject.transform.position.z);
		}
	}
	
}
