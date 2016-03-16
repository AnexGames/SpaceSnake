using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	
	public bool isPaused;
	public bool pauseLabel;
	
	public float native_width = 1920;
	public float native_height = 1080;
	
	public GUIStyle style;
	
	// Use this for initialization
	void Awake () {
		PauseOnStart();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isPaused = true){
			if(Input.GetKey("space")){
				Time.timeScale = 1;
				isPaused = false;
				pauseLabel = false;
			}
		}
	}
	
	void PauseOnStart(){
		isPaused = true;
		Time.timeScale = 0;
		
		
	}
	
	void OnGUI(){
		float rx = Screen.width / native_width;
		float ry = Screen.height / native_height;
		GUI.matrix = Matrix4x4.TRS(new Vector3 (0,0,0), Quaternion.identity, new Vector3(rx,ry,1));
		
		if(pauseLabel){
			GUI.Label(new Rect(650, 540, 200, 200), "Press Space to start", style);
		}
	}
}
