using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class randomMovement : MonoBehaviour {
	
	public static float playerSpeed = 30.0f;
	public static bool isDead;
	
	//Create our snake list that holds head and body objects
	public List <GameObject> snakeUpdate = new List<GameObject>();
	
	//prefab for our snake body object
	public GameObject snakeBody;
	
	public float rotationSpeed = 1f;
	
	//space between snake body pieces
	public float offset = 10.0f;
	public float timer =0f;
	public float updateEvery = 1f;
	
	//Movement keys
	private bool left;
	private bool right;
	private bool up;
	private bool down;
		

	// Use this for initialization
	void Start () {
		
		//set player isDead to false
		isDead = false;
		
		//Add head object to list at 0 posiiton
		snakeUpdate.Add(this.gameObject);
		
		//Add 3 body pieces at start of the game
		for(int i = 0; i < 3; i++){
			
			
			GameObject h = Instantiate(snakeBody, new Vector3(0, offset, 0), transform.rotation)as GameObject;
			offset -=3;
			snakeUpdate.Add(h);
		}
		//StartCoroutine(DrawSnake_delay());
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//transform.position += new Vector3(0, 4 * Time.deltaTime * playerSpeed, 0);
	transform.Translate (Vector3.up);
		//if player is not dead
		if(!isDead){
		 		
			//StartCoroutine(Movement());
			//Update snake position
			DrawSnake();
	
			//When play button is pressed snake will start moving up 
			//transform.Translate(Vector3.up * Time.deltaTime);
			
			
			//transform.position += new Vector3(0,3,0);
			
			if(Input.GetKey ("up")&& !down) {
				up = true;
				down = false;
				left = false;
				right = false;
				
				//rotate snake 90 degrees upward
				transform.up = Vector3.Slerp(Vector3.up, Vector3.up ,rotationSpeed * Time.deltaTime);
				
			}
			
			else if(Input.GetKey ("down") && !up){
				up = false;
				down = true;
				left = false;
				right = false;
				
				//rotate snake 90 degrees down 
				transform.up = Vector3.Slerp(Vector3.up, -Vector3.up ,rotationSpeed * Time.deltaTime);
				
			}
			
			else if(Input.GetKey ("left") && !right ){
				up = false;
				down = false;
				left = true;
				right = false;
				
				//rotate snake 90 degrees left
				transform.up = Vector3.Slerp(Vector3.up, Vector3.left ,rotationSpeed * Time.deltaTime);
				
				
			}
			
			else if(Input.GetKey ("right") && !left){
				up = false;
				down = false;
				left = false;
				right = true;
				
				//rotate snake 90 degrees right
				transform.up = Vector3.Slerp(Vector3.up, Vector3.right ,rotationSpeed * Time.deltaTime);	
			}
		
		}
		
	}

	

	
//	public IEnumerator DrawSnake_delay(){
//		for (int i = (snakeUpdate.Count - 1); i > 0; i--){
//			yield return new WaitForSeconds(1.0f);	
//			//give that object the position of object in front
//			snakeUpdate[i].transform.position = snakeUpdate[i-1].transform.position;
//		
//		}
//	}
	
	
	
	public void DrawSnake(){
		//for every object in list 
		for (int i = (snakeUpdate.Count - 1); i > 0; i--){
			
			//give that object the position of object in front
			snakeUpdate[i].transform.position = snakeUpdate[i-1].transform.position;
			
		}
	}
	
	
	
	void OnTriggerEnter(Collider col){
			
		
		if(col.gameObject.tag == "Food"){
			//Spawn body object on food pickup
			snakeUpdate.Add( (GameObject) Instantiate(snakeBody));
		}
		
		//if player hits corner wall
		if(col.gameObject.tag == "Wall"){
			
			isDead = true;
			Destroy(this.gameObject);
			
			//for every object in the list destroy on collision
			for(int i = 0; i < snakeUpdate.Count; i++){
				Destroy(snakeUpdate[i]);
			}
			
			//Spawn snake 
			PlayerSpawn.SpawnPlayer();
		}
	}
}
	
	

