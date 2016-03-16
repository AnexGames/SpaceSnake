using UnityEngine;
using System.Collections;

public class TotalScore : MonoBehaviour {
	public UILabel _totalScore;
	public UILabel _highScore;
	public GameObject deathScreen;

	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		_highScore.text = "HIGH SCORE: " + PlayerPrefs.GetFloat("HighScore_Maze");
		_totalScore.text = "SCORE: " + GameManager.totalScore;
		
		if(PlayerMovement.isDead == true)
			NGUITools.SetActive(deathScreen, true);
			
	}
}
