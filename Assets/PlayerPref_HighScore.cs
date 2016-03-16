using UnityEngine;
using System.Collections;

public class PlayerPref_HighScore : MonoBehaviour {
	public static float currentScore;
	public UILabel label;
	// Use this for initialization
	void Awake(){
		
		if(Arcade_Load._arcade == false){
		
		if(!PlayerPrefs.HasKey("HighScore_Maze")){
			PlayerPrefs.SetFloat("HighScore_Maze", 0);
			}
		}
		
		else{
			if(!PlayerPrefs.HasKey("Arcade_HighScore")){
				PlayerPrefs.SetFloat("Arcade_HighScore", 0);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		currentScore = GameManager.totalScore;
		
		if(Arcade_Load._arcade == false){	
			label.text = "High Score: " + PlayerPrefs.GetFloat("HighScore_Maze");
		}
		else{
			label.text = "High Score: " + PlayerPrefs.GetFloat("Arcade_HighScore");	
		}
	
	}
	
	public static void SetHighScore(){
		if(Arcade_Load._arcade == false){	
			if(currentScore > PlayerPrefs.GetFloat("HighScore_Maze")){
				PlayerPrefs.SetFloat("HighScore_Maze", currentScore);	
			}	
			
		}
		
		else{
			if(currentScore > PlayerPrefs.GetFloat("Arcade_HighScore")){
				PlayerPrefs.SetFloat("Arcade_HighScore", currentScore);
			}
		}
		
	}
}
