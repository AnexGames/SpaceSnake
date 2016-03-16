using UnityEngine;
using System.Collections;

public class _super : MonoBehaviour {
	
	//Set up grid for alignment 
	public GFGrid grid;
	public Transform cachedTransform;
	
	//vector3 for random position 
	private Vector3 foodPosition;
	
	//Set up timer variables for superfood 
	//Will evaluate and change 
	public float tickTime = 15.0f;
	public float sinceLastTick = 0f;
	public AudioClip audio;

	//score tween vars
	public FloatingScore prefab;
	public GameObject _target;
	public Transform parent;
	
	public GameObject _particles;
	public Transform _particles_spawn;
	
	void Start(){
		
//		cachedTransform = this.gameObject.transform;
//		
//		if(grid){
//			grid.AlignTransform(cachedTransform);
//		}
	}
	

	//IEnumerator WaitAndDestroy(){
	// Score Tween method 
	public IEnumerator ScoreTween() {
		
		FloatingScore fs = Instantiate(prefab) as FloatingScore;
		
		Vector3 size = fs.transform.localScale;
		
		fs.SpawnAt(_target, parent, size);

		fs.Init(Color.white, "+ " + GameManager._super * ScoreMultiplier.multiplier, _target);
		
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
	
	void OnTriggerEnter(Collider col){
		
		//When snake head collides with food object
		if(col.gameObject.tag == "Player"){
			
			Instantiate(_particles, _particles_spawn.position, Quaternion.identity);
			StartCoroutine(ScoreTween());
			
			
			Zone1.bonusCount -= 1;
			Zone2.bonusCount2 -= 1;
			Zone3.bonusCount3 -= 1;
			Zone4.bonusCount4 -=1;
			//ScoreMultiplier.multiplier += 0.5f;
			//call our score script and add to total score var
			//score.totalScore += score.superScore[score.super];
			GameManager.totalScore += GameManager._super * ScoreMultiplier.multiplier;
			
			Destroy(this.gameObject);
			
			if(audio)
				AudioSource.PlayClipAtPoint(audio, transform.position);
				

			
		}
	}
}
