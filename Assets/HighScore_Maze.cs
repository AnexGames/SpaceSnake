using UnityEngine;
using System.Collections;

public class HighScore_Maze : MonoBehaviour {
	public UILabel mazeL;
	// Use this for initialization
	void Start () {
		if(!PlayerPrefs.HasKey("HighScore_Maze")){
			PlayerPrefs.SetFloat("HighScore_Maze", 0);
		}
		
		mazeL.text = "Maze High Score: " + PlayerPrefs.GetFloat("HighScore_Maze");
	}
	
	
}
