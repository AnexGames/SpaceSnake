using UnityEngine;
using System.Collections;

public class Countdown : MonoBehaviour {
	public UILabel _countdown;
	public GameObject _c;
	
	private string textTime;
	private float restSeconds;
	private int roundedRest;
	private int minutes;
	private int seconds;

	
	// Update is called once per frame
	void Update () {
		
	if(Zone1.isTriggered == true || Zone2.isTriggered == true || Zone3.isTriggered == true){
		
		NGUITools.SetActive(_c, true);
		
		restSeconds -= Time.deltaTime;
		roundedRest = Mathf.CeilToInt(restSeconds);
		
		seconds = roundedRest%60;
		minutes = roundedRest/60;
		textTime = string.Format("{0}:{1:00}", minutes, seconds);
		_countdown.text = textTime;
		
		}
			
	
		//_countdown.text = restSeconds.ToString();
		if(seconds <= 0 && minutes <= 0 || FinalMazePickup.mazeTrigger == true){
			
			Zone1.isTriggered = false; 
			Zone2.isTriggered = false;
			Zone3.isTriggered = false;
			NGUITools.SetActive(_c, false);
			restSeconds = 30;
			
		}
	}
}
