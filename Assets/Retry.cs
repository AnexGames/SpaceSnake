using UnityEngine;
using System.Collections;

public class Retry : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public IEnumerator LoadAfterAudio(){
		yield return new WaitForSeconds(1.0f);
		
		Application.LoadLevel(2);
	}
	void OnClick(){
		StartCoroutine(LoadAfterAudio());
		ScoreMultiplier.multiplier = 1.0f;
		GameManager.foodPicked = 0;
		GameManager.foodPickedTotal = 0;
	}
}
