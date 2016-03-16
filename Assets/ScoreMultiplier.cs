using UnityEngine;
using System.Collections;

public class ScoreMultiplier : MonoBehaviour {
	public UILabel multiText;
	public static float multiplier = 1.0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		multiText.text = "X "  + multiplier.ToString();
	}
}
