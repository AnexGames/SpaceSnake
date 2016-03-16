using UnityEngine;
using System.Collections;

public class AnexGames_Fade : MonoBehaviour {
	public float _t = 5;
	public bool stopTimer;
	
	// Use this for initialization
	void Start () {
		stopTimer = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(stopTimer == true){
			_t -= Time.deltaTime;
			
			if(_t <= 0){
				stopTimer = false;
				Application.LoadLevel(1);
			}
		}
	}
}
