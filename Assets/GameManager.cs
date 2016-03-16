using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	//VARIABLES FOR NGUI
	
	public UILabel scoreText;
	public UILabel scoreTween;
	//declare variables
	static public float totalScore;
	static public float foodScore;
	static public int[] superScore;
	static public float _super;
	static public int super;
	
	static public int movesToFood = 0;
	static public int[] movesScore = new int[8];
	
	static public int foodPicked = 0;
	public bool goalReached = true;
	public float scoreHeight;
	public float scoreWidth;

	public Camera mainCamera;
	public GFGrid grid;
	
	//Gui Resolution 
	public float native_width = 1920;
	public float native_height = 1080;
	public GUIStyle style;
	
	public GameObject arrow1;
	public GameObject arrow2;

	public int foodGoal = 10;
	static public int lvl = 1;
	static public int foodPickedTotal = 0;
	private string levelAnim;
	public string winString;
	public GameObject food;
	//lasers _-REDO
	public GameObject laser;
	
	public GameObject laser2a;
	public GameObject laser2b;
	
	public GameObject laser3a;
	public GameObject laser3b;

	public GameObject laser4a;
	public GameObject laser4b;
	
	public GameObject laser5a;
	public GameObject laser5b;
	
	public static bool isCamMoving;
	//Zone Pickup bool;
	private bool zonePickup;
	static public int zoneGoal = 0;
	
	public float maxTime = 0.08f;
	
	void Awake(){
		
		//Screen.autorotateToLandscapeLeft = true;
	}
	// Use this for initialization
	void Start () {
	
		//set our score variables for food/super/ and turn bonus
		superScore = new int[5];
		
		superScore[0] = 5000;
		superScore[1] = 10000;
		superScore[2] = 12000;
		superScore[3] = 15000;
		superScore[4] = 20000;
		
		super = Random.Range(0, superScore.Length);
		
		movesScore[0] = 1000;
		movesScore[1] = 750;
		movesScore[2] = 500;
		movesScore[3] = 250;
		movesScore[4] = 100;
		movesScore[5] = 50;
		
		totalScore = 0;
		_super = 100;
		foodScore = 1000;
		levelAnim = "Level 2 Grid Final";
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		//scoreText.text = "SCORE: " + totalScore;
		scoreText.text = string.Format("Score: {0:0000000}", totalScore);
		//scoreTween.
		//scoreTween.transform.position = new Vector3(food.transform.position.x, food.transform.position.y, food.transform.position.z);
		//TweenPosition.Begin(scoreTween.gameObject, 3.0f, food.transform.position);
		//TweenAlpha.Begin(scoreTween.gameObject, 1.0f, 0f);
		
		if(foodPicked >= 50){
			PlayerMovement.isDead = true;	
		}
		
		else if(foodPickedTotal >= 10 ){ 
			
			
			
			if(PlayerMovement.tickTime <= maxTime){
					PlayerMovement.tickTime -= 0.01f;
			}
			
			PlayerMovement.startTimer = false;
			foodPickedTotal = 0;
			hoMove move = gameObject.GetComponent<hoMove>();
			move.Resume();
	
			foodGoal += 10;
			//turn barrier (laser) off
			lvl ++;
			grid.GetComponent<Animation>().Play(levelAnim);
//			laser.SetActive(false);
//			laser2a.SetActive(false);
//			laser2b.SetActive(false);
//     		laser3a.SetActive(false);
//			laser3b.SetActive(false);
//			laser4a.SetActive(false);
//			laser4b.SetActive(false);
//			
			
		
//			arrow1.SetActive(true);
//			arrow2.SetActive(true);
			
			
//			//when player has picked up enough food move camera up and transition to new lvl
//			//Animation will be used when we finalize it

		}
		
		if(foodPickedTotal >= 40){
			PlayerMovement.isDead = true;
			winString = "YOU PASSED ALL THE LEVELS! THANKS FOR PLAYING!";
			
		}
	//if(zoneGoal >= 12 && CanCamMove.inReach == true){
		if(zoneGoal >= 8){
			RedCoinTrigger.timerGoing = false;
			RedCoin2.timerGoing = false;
			RedCoin3.timerGoing = false;
			RedCoin4.timerGoing = false;
			ScoreMultiplier.multiplier += 1.0f;
			zoneGoal = 0;
			hoMove move = gameObject.GetComponent<hoMove>();
			move.Resume();
			
			
			
			
		}
		
//		if(Barrier.deadTrigger == true){
//			hoMove move = gameObject.GetComponent<hoMove>();
//			move.Resume();	
//			Barrier.deadTrigger = false;
//		}
	//if(FinalMazePickup.mazeTrigger == true && CanCamMove.inReach == true){
	if(FinalMazePickup.mazeTrigger == true){
			PlayerMovement.startTimer = true;
			isCamMoving = true;
			hoMove move = gameObject.GetComponent<hoMove>();
			move.Resume();
			Barrier.deadTrigger = false;
		}
			
	}
	
	
	void Method1(){
		//iMove moveScript = gameObject.GetComponent<iMove>();
		hoMove move = gameObject.GetComponent<hoMove>();
		move.Pause();  
		//laser.SetActive(true);
		
		
	}
	
	void Method2(){
		//iMove moveScript = gameObject.GetComponent<iMove>();
			Debug.Log("Method 2");
		hoMove move = gameObject.GetComponent<hoMove>();
		move.Pause();
		WarningArrows.arrowBool = false;
		levelAnim = "level 3 Grid Final";
		//laser2a.SetActive(true);
		//laser2b.SetActive(true);
		
		Vector3 lowerBound = -grid.size;
		Vector3 upperBound = grid.size;
	
		float x = Random.Range (lowerBound.x  , upperBound.x );
		float y = Random.Range (lowerBound.y  , upperBound.y );
		
		_food.foodPosition = new Vector3(x + grid.transform.position.x, y+ grid.transform.position.y, -0.5f);
		
		food.transform.position = _food.foodPosition;
		grid.AlignTransform(food.transform);
	}
	
	void Method3(){
			Debug.Log("Method 3");
		FinalMazePickup.mazeTrigger = false;
		WarningArrows.arrowBool = false;
		hoMove move = gameObject.GetComponent<hoMove>();
		move.Pause();
		levelAnim = "Level 3 Grid Final";
		//laser3a.SetActive(true);
		//laser3b.SetActive(true);
		
//		Vector3 lowerBound = -grid.size;
//		Vector3 upperBound = grid.size;
//	
//		float x = Random.Range (lowerBound.x  , upperBound.x );
//		float y = Random.Range (lowerBound.y  , upperBound.y );
//		
//		_food.foodPosition = new Vector3(x + grid.transform.position.x, y+ grid.transform.position.y, -0.5f);
//		
//		food.transform.position = _food.foodPosition;
//		
//		grid.AlignTransform(food.transform);
		
		
	}
	
	void Method4(){
			Debug.Log("Method 4");
		if(isCamMoving == false){
			FinalMazePickup.mazeTrigger = false;
		}
		WarningArrows.arrowBool = false;
		//FinalMazePickup.mazeTrigger = false;
		hoMove move = gameObject.GetComponent<hoMove>();
		move.Pause();
		
		//laser4a.SetActive(true);
		//laser4b.SetActive(true);
//	
		Vector3 lowerBound = -grid.size;
		Vector3 upperBound = grid.size;
	
		float x = Random.Range (lowerBound.x  , upperBound.x );
		float y = Random.Range (lowerBound.y  , upperBound.y );
		
		_food.foodPosition = new Vector3(x + grid.transform.position.x, y+ grid.transform.position.y, -0.5f);
		
		food.transform.position = _food.foodPosition;
		
		grid.AlignTransform(food.transform);
		
	}
	
		void Method5(){
			Debug.Log("Method 5");
		FinalMazePickup.mazeTrigger = false;
		hoMove move = gameObject.GetComponent<hoMove>();
		WarningArrows.arrowBool = false;
		move.Pause();
		levelAnim = "Level 4 Grid Final";
		//laser5a.SetActive(true);
		//laser4b.SetActive(true);
	
//		Vector3 lowerBound = -grid.size;
//		Vector3 upperBound = grid.size;
//	
//		float x = Random.Range (lowerBound.x  , upperBound.x );
//		float y = Random.Range (lowerBound.y  , upperBound.y );
//		
//		_food.foodPosition = new Vector3(x + grid.transform.position.x, y+ grid.transform.position.y, -0.5f);
//		
//		food.transform.position = _food.foodPosition;
//		
//		grid.AlignTransform(food.transform);
		
	}
	
	void Method6(){
		Debug.Log("Method 6");
		if(isCamMoving == false){
			FinalMazePickup.mazeTrigger = false;
		}
		//FinalMazePickup.mazeTrigger = false;
		WarningArrows.arrowBool = false;
		hoMove move = gameObject.GetComponent<hoMove>();
		move.Pause();
		levelAnim = "Level 5 Grid Final";
	//	laser4a.SetActive(true);
		//laser4b.SetActive(true);
	
		Vector3 lowerBound = -grid.size;
		Vector3 upperBound = grid.size;
	
		float x = Random.Range (lowerBound.x  , upperBound.x );
		float y = Random.Range (lowerBound.y  , upperBound.y );
		
		_food.foodPosition = new Vector3(x + grid.transform.position.x, y+ grid.transform.position.y, -0.5f);
		
		food.transform.position = _food.foodPosition;
		
		grid.AlignTransform(food.transform);
		
	}
	
	void Method7(){
			Debug.Log("Method 7");
		FinalMazePickup.mazeTrigger = false;
		WarningArrows.arrowBool = false;
		hoMove move = gameObject.GetComponent<hoMove>();
		move.Pause();
		levelAnim = "Level 5 Grid Final";
	//	laser4a.SetActive(true);
		//laser4b.SetActive(true);
	
//		Vector3 lowerBound = -grid.size;
//		Vector3 upperBound = grid.size;
//	
//		float x = Random.Range (lowerBound.x  , upperBound.x );
//		float y = Random.Range (lowerBound.y  , upperBound.y );
//		
//		_food.foodPosition = new Vector3(x + grid.transform.position.x, y+ grid.transform.position.y, -0.5f);
//		
//		food.transform.position = _food.foodPosition;
//		
//		grid.AlignTransform(food.transform);
		
	}
	
	void Method8(){
		Debug.Log("Method 8");
			if(isCamMoving == false){
			FinalMazePickup.mazeTrigger = false;
		}
		//FinalMazePickup.mazeTrigger = false;
		WarningArrows.arrowBool = false;
		hoMove move = gameObject.GetComponent<hoMove>();
		move.Pause();
		levelAnim = "Level 5 Grid Final";
	//	laser4a.SetActive(true);
		//laser4b.SetActive(true);
	
		Vector3 lowerBound = -grid.size;
		Vector3 upperBound = grid.size;
	
		float x = Random.Range (lowerBound.x  , upperBound.x );
		float y = Random.Range (lowerBound.y  , upperBound.y );
		
		_food.foodPosition = new Vector3(x + grid.transform.position.x, y+ grid.transform.position.y, -0.5f);
		
		food.transform.position = _food.foodPosition;
		
		grid.AlignTransform(food.transform);
		
	}
	
	void Method9(){
		Debug.Log("Method 9");
		WarningArrows.arrowBool = false;
		FinalMazePickup.mazeTrigger = false;
		
		hoMove move = gameObject.GetComponent<hoMove>();
		move.Pause();
	}
		
		
		
	
//	void OnGUI(){
//		float rx = Screen.width / native_width;
//		float ry = Screen.height / native_height;
//		GUI.matrix = Matrix4x4.TRS(new Vector3 (0,0,0), Quaternion.identity, new Vector3(rx,ry,1));
//		
//		if(PlayerMovement.isDead == true){
//			
//			GUI.Label(new Rect(scoreWidth, scoreHeight + 400, 300, 300), "Your Score: " + totalScore, style);
//			
//			if (GUI.Button( new Rect(scoreWidth , scoreHeight + 450,400, 400), "Try Again", style))
//				
//				Application.LoadLevel("Arcade Prototype scene");
//				foodPicked = 0;
//				foodPickedTotal = 0;
//				lvl = 0;
//				
//				
//		}
//		GUI.Label(new Rect(scoreWidth, scoreHeight + 350, 300, 300), winString, style);
//		GUI.Label(new Rect( scoreWidth, scoreHeight + 50, 200, 200), "Move Bonus: "+"+ " + _food.bonusScore, style);
//		GUI.Label(new Rect( scoreWidth, scoreHeight, 200, 200), "SCORE: " + totalScore, style);
//		GUI.Label(new Rect(10, 10, 100, 100), "LEVEL: " + lvl, style);
//		GUI.Label(new Rect(30, 80, 100,100) ,movesToFood + " MOVES!!", style);
//		GUI.Label(new Rect(400,80, 100,100) ,foodPicked + " / " + foodGoal, style);
//		
//	
//	}
//	
}

