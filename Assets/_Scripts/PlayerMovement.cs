using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {
	
	public GFRectGrid myGrid; //grid reference
	public Transform cached;
	public static bool isTeleported;
	public float playerSpeed = 30.0f;
	public static bool isDead;
	public bool isPaused;
	public static GameObject snakeHead;
	
	public GameObject foodParticles;
	
	//Create our snake list that holds head and body objects
	public List <GameObject> snakeUpdate = new List<GameObject>();
	
	//prefab for our snake body object
	public GameObject snakeBody;
	public GameObject food;
	public Vector3 rotation;
	
	public ParticleSystem _p;
	//space between snake body pieces
	public static float tickTime = 1f;
	private float sinceLastTick = 0f;
	
	//private Vector3 nextDir;
	public static Vector3 nextDir;
	//direction to start
	public Vector3 direction = new Vector3(1,0,0);
	
	//Movement keys
	 bool left;
	 bool right = true;
	 bool up;
	 bool down;
	
	//Teleports 
	public GameObject teleport1;
	public GameObject teleport2;
	public GameObject teleport3;
	public GameObject teleport4;
	public GameObject teleport5;
	public GameObject teleport6;
	
	//Vector3[] directions;
	int i;
	public AudioClip death;
	public static bool playAudio;
	public Vector3 move = Vector3.zero;
	public static float gameTime = 0;
	
	//Jump Vars
	private bool isJumped;
	public static bool canJump;
	public static bool startTimer = false;
	private float jumpTick = 0f;
	public float jumpTickTime = 10f;
	
	void Awake(){ 
	
		//set framerate to 60
		//Application.targetFrameRate = 60;
		this.gameObject.GetComponent<Renderer>().material.mainTexture = Resources.Load(PlayerPrefs.GetString("HeadTexture"),typeof(Texture2D)) as Texture2D;
		//auto rotate screen
		//Screen.autorotateToLandscapeLeft = true;
	
		//set our transform var to this transform
		cached = this.transform;
		
		if(myGrid){
			myGrid.AlignTransform(cached);
		}
	}
			
	// Use this for initialization
	void Start () {
		canJump = true;
		snakeHead = this.gameObject;
		tickTime = 0.14f;
		//Resolution[] resolutions = Screen.resolutions;
		
		//Screen.SetResolution (resolutions[0].width, resolutions[0].height, true);
		
		
		//set player isDead to false
		isDead = false;
		nextDir = myGrid.right;
		//Add head object to list at 0 posiiton
		snakeUpdate.Add(this.gameObject);
		
		//Add 3 body pieces at start of the game
		for(int i = 0; i < 3  ; i++){
			
			//I'm instantiating 3 body objects at the start of the game off the screen.
			GameObject h = Instantiate(snakeBody, new Vector3(100,100,100), transform.rotation)as GameObject;
			
			//offset -=4;
			//Add objects to list
			snakeUpdate.Add(h);
		
		}
		
		
	}
	
	//TAP CONTROLS ---------------------------
	// Subscribe to events
//	void OnEnable(){
//		EasyTouch.On_TouchStart+= On_TouchStart;
//		
//	}
//	// Unsubscribe
//	void OnDisable(){
//		EasyTouch.On_TouchStart -= On_TouchStart;
//		
//	}
//	// Unsubscribe
//	void OnDestroy(){
//		EasyTouch.On_TouchStart -= On_TouchStart;
//		
//	}
//	// At the touch beginning
//	public void On_TouchStart(Gesture gesture){
//		i++;
//		
//		
//		
//		// Verification that the action on the object
//		
//		if(i == 1 ){
//			direction = myGrid.up;
//			
//			up = true;
//			down = false;
//			left = false;
//			right = false;
//		}
//		
//	
//		
//		if(i == 2 ){
//			direction = -myGrid.right;
//			up = false;
//			down = false;
//			left = true;
//			right = false;
//			
//		}
//		
//		if(i == 3){
//			direction = -myGrid.up;
//			up = false;
//			down = true;
//			left = false;
//			right = false;
//		}
//		
//		if(i == 4){
//			direction = myGrid.right;
//			i = 0;
//			up = false;
//			down = false;
//			left = false;
//			right = true;
//		}
//	}
	
	//swipe controls
	void OnEnable(){
		EasyTouch.On_SwipeStart += On_SwipeStart;
		EasyTouch.On_Swipe += On_Swipe;
		EasyTouch.On_SwipeEnd += On_SwipeEnd;		
	}

	void OnDisable(){
		UnsubscribeEvent();
		
	}
	
	void OnDestroy(){
		UnsubscribeEvent();
	}
	
	void UnsubscribeEvent(){
		EasyTouch.On_SwipeStart -= On_SwipeStart;
		EasyTouch.On_Swipe -= On_Swipe;
		EasyTouch.On_SwipeEnd -= On_SwipeEnd;	
	}
	
		// At the swipe beginning 
	private void On_SwipeStart( Gesture gesture){
	
		// Only for the first finger
		if (gesture.fingerIndex==0){ 
			
			// the world coordinate from touch for z=5
			Vector3 position = gesture.GetTouchToWordlPoint(5);
		
		}
	}
	
	// During the swipe
	private void On_Swipe(Gesture gesture){
		
//		// the world coordinate from touch for z=5
//			Vector3 position = gesture.GetTouchToWordlPoint(5);
		

		
	}
	
	// At the swipe end 
	private void On_SwipeEnd(Gesture gesture){
		if(isTeleported == false){
			if(gesture.swipe == EasyTouch.SwipeType.Down){
				nextDir= -myGrid.up;
			}
			
			if(gesture.swipe == EasyTouch.SwipeType.Left){
				nextDir = -myGrid.right;
			}
			
			if(gesture.swipe == EasyTouch.SwipeType.Right){
				nextDir = myGrid.right;
			}
			
			if(gesture.swipe == EasyTouch.SwipeType.Up){
				nextDir = myGrid.up;
			}
		}
		
		else if(isTeleported == true){
			if(gesture.swipe == EasyTouch.SwipeType.Down){
			direction = -myGrid.up;
				isTeleported = false;
				
		}
		
		 else if(gesture.swipe == EasyTouch.SwipeType.Left){
			direction = -myGrid.right;
				isTeleported = false;
				
		}
		
		else if(gesture.swipe == EasyTouch.SwipeType.Right){
			direction = myGrid.right;
				isTeleported = false;
			
		}
		
		else if(gesture.swipe == EasyTouch.SwipeType.Up){
			direction = myGrid.up;
				isTeleported = false;
				
		}
		}
				
	}
	
	void Update () {
		if(playAudio == true){
			if(GetComponent<AudioSource>())
            {
				AudioSource.PlayClipAtPoint(death, transform.position);
			}
			playAudio = false;
			
		}
		snakeHead = snakeUpdate[0].gameObject;
		
		//if player is not dead
		if(!isDead){
			//Timer for Jump
			if(canJump == false){
				if(startTimer == true){
					jumpTick += Time.deltaTime;
					if(jumpTick > jumpTickTime){
						canJump = true;
						jumpTick -= jumpTickTime;
					}
				}
			}
					
						
			//update position and cache to grid 
			//set our transform var to this transform
			//My tick timer that updates position of snake
			
				
			if(isTeleported == false){
				sinceLastTick += Time.deltaTime;
				if (Input.GetKey(KeyCode.UpArrow))    nextDir = myGrid.up;
	    		else if (Input.GetKey(KeyCode.DownArrow))  nextDir = -myGrid.up;
	  			else if (Input.GetKey(KeyCode.LeftArrow))  nextDir = -myGrid.right;
	    		else if (Input.GetKey(KeyCode.RightArrow)) nextDir = myGrid.right;
				
				if(startTimer == true){
					if(canJump == true){
						if(Input.GetKeyDown("space")){
							isJumped = true;
							}
						}
				}
					
				if(sinceLastTick > tickTime){
						if(isJumped == true){
							StartCoroutine(snakeJump());
							startTimer = true;
							canJump = false;
							isJumped = false;
						}
						
						else if (-nextDir != direction) {
	  						 direction = nextDir;
							
						}
						DrawSnake();
						cached.position += direction;
						
				
						GameManager.totalScore += 1;
						
						
						sinceLastTick -= tickTime;
						
					}
				
				}
				
				else if(isTeleported == true){
					StartCoroutine(TeleportSnake());	
				}
			}
		

			
		
	}
	
	
	public IEnumerator snakeJump(){
		
		snakeHead.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
		yield return new WaitForSeconds(0.5f);
		snakeHead.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
			
	}
//	
//	public IEnumerator snakeMove(Transform transform){
//		Vector3 startPosition = snakeUpdate[0].transform.position;
//		
//		Vector3 endPosition = snakeUpdate[0].transform.position + direction;
//		
//		float t = 0;
//		
//		while(t < 1f){
//			t += Time.deltaTime;
//			HeadMovement();
//			DrawSnake();
//			
//			
//			transform.position = Vector3.Lerp(startPosition, endPosition,1);
//			
//			yield return null;
//		}
//		
//		yield return 0;
//	}
//		
//	
	// Keep track of inputs and change direction variable depending on key press
	public void HeadMovement(){
		
		if(Input.GetKeyDown("up") && !down) {
			up = true;
			down = false;
			left = false;
			right = false;
			
			score.movesToFood += 1;
				
			direction = myGrid.up;
			
			cached.position += direction; 
			//cached.Translate(direction);
			
			//rotate snake 90 degrees upward
			//transform.up = Vector3.Slerp(Vector3.up, Vector3.up ,rotationSpeed * Time.deltaTime);
			
				
		}
		
		else if( Input.GetKeyDown ("down") && !up){
			up = false;
			down = true;
			left = false;
			right = false;
				
			score.movesToFood += 1;	
			
			direction = -myGrid.up;
			
			cached.position += direction; 
			//cached.Translate(direction);	
			
			//rotate snake 90 degrees down 
			//transform.up = Vector3.Slerp(Vector3.up, -Vector3.up ,rotationSpeed * Time.deltaTime);
			
		}
		
		else if(Input.GetKeyDown ("left") && !right ){
			up = false;
			down = false;
			left = true;
			right = false;
				
			score.movesToFood += 1;
			
			direction = -myGrid.right;
			
			cached.position += direction; 
			//cached.Translate(direction);
			
			//rotate snake 90 degrees left
			//transform.up = Vector3.Slerp(Vector3.up, Vector3.left ,rotationSpeed * Time.deltaTime);
			
			
		}
		
		else if(Input.GetKeyDown ("right") && !left){
			up = false;
			down = false;
			left = false;
			right = true;
			//DrawSnake();	
			score.movesToFood += 1;
				
			direction = myGrid.right;
			
		cached.position += direction; 
			//cached.Translate(direction);
			
			//rotate snake 90 degrees right
			//transform.up = Vector3.Slerp(Vector3.up, Vector3.right ,rotationSpeed * Time.deltaTime);	
			
		}
		
//		if(Input.GetKeyDown("space")){
//		   // TweenPosition tp = GetComponent<TweenPosition>();
//			//tp = gameObject.AddComponent<TweenPosition>();
//			direction = Vector3.zero;
//			
//			GameObject _snake;
//			_snake = GameObject.Find("Snake");
//			_snake.transform.animation.Play("Jump");
//			//tp.duration = 1;
//			//animation.Play();
//			//iTween.MoveUpdate(this.gameObject, new Vector3( transform.position.x,transform.position.y, transform.position.z - 1), 1.0f);
//			//iTween.MoveUpdate(this.gameObject, iTween.Hash("position", transform.position += 
//			
//			//snakeUpdate[0].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
//			//TweenPosition.Begin(this.gameObject, 1f,  new Vector3(transform.position.x, transform.position.y, transform.position.z - 1)); 
//			
//			//tp.from = transform.position;
//			//tp.to = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
//			//tp.onFinished += MoveBack;
//			
//			//MoveBack();
//			
//			//tp.onFinished
//			
//			
//		}
	}

	public void MoveBack(){
		iTween.MoveUpdate(this.gameObject, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), 1.0f);	
	}
	//this function draws the snakebody every tick 
	public void DrawSnake(){
		
		//for every object in list 
		for (int i = (snakeUpdate.Count - 1); i > 0; i--){
			
			//give that object the position of object in front
			snakeUpdate[i].transform.position = snakeUpdate[i-1].transform.position;
			
			
		}
	}
	
	//function keeps track of teleporting snake and inputing direction after teleport 
	public IEnumerator TeleportSnake(){
		
		
		yield return new WaitForSeconds(0.3f);
		
		while(isTeleported == true){
		
			yield return null;
			
	
			
			if (Input.GetKey(KeyCode.UpArrow)){ 
				direction = myGrid.up;
				isTeleported = false;
				yield break;
			}
    		else if (Input.GetKey(KeyCode.DownArrow)){
				direction = -myGrid.up;
				isTeleported = false;
				yield break;
			}
  			else if (Input.GetKey(KeyCode.LeftArrow)){
				direction = -myGrid.right;
				isTeleported = false;
				yield break;
			}
    		else if (Input.GetKey(KeyCode.RightArrow)){
				direction = myGrid.right;
				isTeleported = false;
				yield break;
			}
			
	
			
			

		
//			if(Input.GetKey("up") && !down) {
//				up = true;
//				down = false;
//				left = false;
//				right = false;
//				
//				score.movesToFood += 1;
//					
//				direction = myGrid.up;
//				isTeleported = false;
//				yield break;
//			}
//			
//			else if( Input.GetKey ("down") && !up){
//				up = false;
//				down = true;
//				left = false;
//				right = false;
//					
//				score.movesToFood += 1;	
//					
//				direction = -myGrid.up;
//				isTeleported = false;
//				yield break;
//			}
//			
//			else if(Input.GetKey ("left") && !right ){
//				up = false;
//				down = false;
//				left = true;
//				right = false;
//					
//				score.movesToFood += 1;
//					
//				direction = -myGrid.right;
//				isTeleported = false;
//				yield break;
//				
//			}
//			
//			else if(Input.GetKey ("right") && !left){
//				up = false;
//				down = false;
//				left = false;
//				right = true;
//					
//				score.movesToFood += 1;
//					
//				direction = myGrid.right;
//						
//				isTeleported = false;
//				yield break;
//			
//			}
		}
	
	}
	
	public IEnumerator ParticleGather(){
		if(!_p.isPlaying){
			_p.Play();
		}
		
		yield return new WaitForSeconds(1f);
		
		_p.emissionRate = 0f;
		
			
		ParticleSystem.Particle[] _par = new ParticleSystem.Particle[_p.particleCount];
		
		for(float t = 0f; t < 1f; t += 0.1f){
			int count = _p.GetParticles(_par);
			for ( int i = 0; i < count; i++){
				_par[i].position = Vector3.Lerp(_par[i].position, snakeUpdate[snakeUpdate.Count - 1].transform.position, Time.deltaTime * 20);
			}
			
			_p.SetParticles(_par, count);
		
		}
        GetComponent<ParticleSystem>().Clear();
	}
			
	
			
		
	void OnTriggerEnter(Collider col){
		
		//if snakehead comes into contact with body destroy snake
		if(col.gameObject.tag == "Body"){
			if(Zone1.isTriggered == false){
				PlayerPref_HighScore.SetHighScore();
				isDead = true;
				for(int i = 0; i < snakeUpdate.Count; i++){
					Destroy(snakeUpdate[0]);
				}
				
			if(GetComponent<AudioSource>())
				AudioSource.PlayClipAtPoint(death, transform.position);
				
			}
			
			else if(Zone1.isTriggered == true){
				
				StartCoroutine(TeleportSnake());
				Debug.Log("Hitself in zone");
			}
			
		}
		if(col.gameObject.tag == "Food"){
			
			//Spawn body object on food pickup
			//instantiate body object on food pickup off the screen and insert it to end of list
			
			snakeUpdate.Add((GameObject) Instantiate(snakeBody, snakeUpdate[1].transform.position, transform.rotation) as GameObject);
			snakeUpdate.Add((GameObject) Instantiate(snakeBody, snakeUpdate[1].transform.position, transform.rotation) as GameObject);
			
			//StartCoroutine(ParticleGather());
			//snakeUpdate[snakeUpdate.Count - 1].gameObject.animation.Play("Cube Scale");
			//snakeUpdate.Add((GameObject) Instantiate(snakeBody, snakeUpdate[1].transform.position, transform.rotation) as GameObject);
			//snakeUpdate.Add((GameObject) Instantiate(snakeBody, snakeUpdate[1].transform.position, transform.rotation) as GameObject);
		}
//		
//		if(col.gameObject.tag == "MazePickup"){
//			//TeleportSnake(teleport4, -1);
//			StartCoroutine(TeleportSnake(teleport4, -1, 0));
//			//direction = -myGrid.up;
//			Debug.Log("PICKUP!");
//		}
//		
//		if(col.gameObject.tag == "MazePickup_2"){
//			//TeleportSnake(teleport2, 1);
//			StartCoroutine(TeleportSnake(teleport2, -1,0));
//			
//		}
//	
//		if (col.gameObject.tag == "MazePickup_3"){
//			//TeleportSnake(teleport1, 1);
//			StartCoroutine(TeleportSnake(teleport1, 0, 1));
//			//direction = -myGrid.up;
//			
//			
//		}
//		
//		if (col.gameObject.tag == "MazePickup_4"){
//			//TeleportSnake(teleport3, -1);
//			StartCoroutine(TeleportSnake(teleport3, 0, -1));
//			
//			
//		}
//		
//		if (col.gameObject.tag == "MazePickup_5"){
//			//TeleportSnake(teleport3, -1);
//			StartCoroutine(TeleportSnake(teleport6, -1, 0));
//			
//			
//		}
//		
//		if (col.gameObject.tag == "MazePickup_6"){
//			//TeleportSnake(teleport3, -1);
//			StartCoroutine(TeleportSnake(teleport5, -1, 0));
//			
//			
//		}
//		if (col.gameObject.name== "Teleport3"){
//			TeleportSnake(teleport4);
//			
//		}
//		if (col.gameObject.name== "Teleport4"){
//			TeleportSnake(teleport3);
//			
//		}
		//if player hits corner wall, destroy head and body and respawn snake
//		if(col.gameObject.tag == "Wall"){
//			
//			isDead = true;
//			Destroy(this.gameObject);
//			
//			//for every object in the list destroy on collision
//			for(int i = 0; i < snakeUpdate.Count; i++){
//				Destroy(snakeUpdate[i]);
//			}

	}
}
	
	


	

	

