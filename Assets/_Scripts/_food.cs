using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class _food : MonoBehaviour {
	
	//Set up grid for alignment 
	public GFGrid grid;
	public Transform cachedTransform;
	public List <Vector3> snakePos = new List<Vector3>();
	//vector3 for random position 
	static public Vector3 foodPosition;	
	
	static public bool foodBonus = true;
	static public int bonusScore;
	
	//ScoreTween Vars
	public GameObject _target;
	public FloatingScore prefab;
	public Transform parent;
	
	public GameObject _particles;
	public Transform _particles_spawn;
	public List<Texture2D> _t = new List<Texture2D>();
	private int textureCounter = 0;
	public GameObject sunGlobe;
	// Use this for initialization
	void Start () {
		
		//set cachedTransform to this connected objects transform
		//cachedTransform.position = foodPosition;
		
		
		//if grid is present align this transform to grid unit
		if(grid){
			grid.AlignTransform(cachedTransform);
		
		}
		
	}
	
	// Score Tween method 
	public IEnumerator ScoreTween() {
		
		FloatingScore fs = Instantiate(prefab) as FloatingScore;
		
		Vector3 size = fs.transform.localScale;
		
		fs.SpawnAt(_target, parent, size);
		
		fs.Init(Color.white, "+ " + GameManager.foodScore * ScoreMultiplier.multiplier, _target);
		
		TweenPosition tp = fs.tweenPos;
		TweenAlpha ta = fs.tweenAlpha;

		
		tp.duration = 2.0f;
		fs.Following();
		
		tp.from = fs.transform.localPosition;
		tp.to = tp.from + Vector3.up * 50;

		ta.duration = 2;
		ta.from = 1;
		ta.to = 0;
		
		yield return new WaitForSeconds(2.0f);
		fs.DestoryMe();
		
	}
	
	void CycleTextures(){
		textureCounter = ++textureCounter % _t.Count;
		sunGlobe.gameObject.GetComponent<Renderer>().material.mainTexture = _t[textureCounter];
	}

	void OnTriggerEnter(Collider col){
			

		//When snake head collides with food object
		if(col.gameObject.tag == "Player"){
			Instantiate(_particles, _particles_spawn.position, Quaternion.identity);
			StartCoroutine(ScoreTween());
			CycleTextures();
            GetComponent<AudioSource>().Play();
			
			//set out int to our current moves
			//int currentMoves = score.movesToFood;
			int currentMoves = GameManager.movesToFood;
			
//			Vector3 lowerBound = grid.useCustomRenderRange? grid.renderFrom : -grid.size;
//			Vector3 upperBound = grid.useCustomRenderRange? grid.renderTo : grid.size;
			
		
			
			//add score bonus .... Change to switch statement. Looks cleaner
			if(currentMoves == 2){
				foodBonus = true;
				score.totalScore += score.movesScore[0];
				bonusScore = score.movesScore[0];
				
				//GameManager
				GameManager.totalScore += GameManager.movesScore[0];
				bonusScore = GameManager.movesScore[0];
			}
			else if(currentMoves == 3){
				foodBonus = true;
				score.totalScore += score.movesScore[1];
				bonusScore = score.movesScore[1];
				
					//GameManager
				GameManager.totalScore += GameManager.movesScore[1];
				bonusScore = GameManager.movesScore[1];
			}
			else if(currentMoves == 4){
				foodBonus = true;
				score.totalScore += score.movesScore[2];
				bonusScore = score.movesScore[2];
				
					//GameManager
				GameManager.totalScore += GameManager.movesScore[2];
				bonusScore = GameManager.movesScore[2];
			}
			else if(currentMoves == 5){
				foodBonus = true;
				score.totalScore += score.movesScore[3];
				bonusScore = score.movesScore[3];
				
					//GameManager
				GameManager.totalScore += GameManager.movesScore[3];
				bonusScore = GameManager.movesScore[3];
			}
			else if(currentMoves == 6){
				foodBonus = true;
				score.totalScore += score.movesScore[4];
				bonusScore = score.movesScore[4];
					//GameManager
				GameManager.totalScore += GameManager.movesScore[4];
				bonusScore = GameManager.movesScore[4];
			}
			else if(currentMoves == 7){
				foodBonus = true;
				score.totalScore += score.movesScore[5];
				bonusScore = score.movesScore[5];
				
					//GameManager
				GameManager.totalScore += GameManager.movesScore[5];
				bonusScore = GameManager.movesScore[5];
			}
			
			//reset our move counter
			score.movesToFood = 0;
			GameManager.movesToFood = 0;

			//call our score script and add to total score var
//			score.foodPicked += 1;
//			score.foodPickedTotal += 1;
//			score.totalScore += score.foodScore;
			
			GameManager.foodPicked += 1;
			GameManager.foodPickedTotal += 1;
			GameManager.totalScore += GameManager.foodScore * ScoreMultiplier.multiplier;
			
			
			Vector3 lowerBound = -grid.size;
			Vector3 upperBound = grid.size;
		
			float x = Random.Range (lowerBound.x  , upperBound.x );
			float y = Random.Range (lowerBound.y  , upperBound.y );
		
			//set up random.range position variables
	    	//foodPosition = new Vector3(Random.Range(-10.4f, 10.4f), Random.Range(-4.9f, 4.0f), 11.8f);
			foodPosition = new Vector3(x + grid.transform.position.x, y+ grid.transform.position.y, transform.position.z);
		
			//have our transform equal our random position
			cachedTransform.position = foodPosition;
			
			//align new position to grid unit
			if(grid){
				grid.AlignTransform(cachedTransform);
				
			}
		
			
			
		
			foodBonus = false;
			
			}
		
		if(col.gameObject.tag == "Body"){
			
			Vector3 lowerBound = -grid.size;
			Vector3 upperBound = grid.size;
		
			float x = Random.Range (lowerBound.x  , upperBound.x );
			float y = Random.Range (lowerBound.y  , upperBound.y );
			
			foodPosition = new Vector3(x + grid.transform.position.x, y+ grid.transform.position.y, transform.position.z);
			
			cachedTransform.position = foodPosition;
			
			grid.AlignTransform(cachedTransform);
		
			
		}
		
		if(col.gameObject.tag == "Barrier"){
			Debug.Log("Hit BARRIER!");
			Vector3 lowerBound = -grid.size;
			Vector3 upperBound = grid.size;
		
			float x = Random.Range (lowerBound.x  , upperBound.x );
			float y = Random.Range (lowerBound.y  , upperBound.y );
			
			foodPosition = new Vector3(x + grid.transform.position.x, y+ grid.transform.position.y, transform.position.z);
			
			cachedTransform.position = foodPosition;
			
			grid.AlignTransform(cachedTransform);
		}
	}
}
