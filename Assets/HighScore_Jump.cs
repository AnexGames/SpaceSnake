using UnityEngine;
using System.Collections;

public class HighScore_Jump : MonoBehaviour {
	public UILabel jumpL;
	// Use this for initialization
	void Start () {
		if(!PlayerPrefs.HasKey("HighScore_Jump")){
			PlayerPrefs.SetFloat("HighScore_Jump", 0);
		}
		
		jumpL.text = "Jump High Score: " + PlayerPrefs.GetFloat("HighScore_Jump");
	}
	

}
