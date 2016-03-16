using UnityEngine;
using System.Collections;

public class HighScore_Coin : MonoBehaviour {
	public UILabel coinL;
	
	// Use this for initialization
	void Start () {
		if(!PlayerPrefs.HasKey("HighScore_Coin")){
			PlayerPrefs.SetFloat("HighScore_Coin", 0);
		}
		
		coinL.text = "Coin High Score: " + PlayerPrefs.GetFloat("HighScore_Coin");
	}
	

}
