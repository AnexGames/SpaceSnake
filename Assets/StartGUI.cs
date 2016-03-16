using UnityEngine;
using System.Collections;

public class StartGUI : MonoBehaviour {
	public float scoreWidth;
	public float scoreHeight;
	
	public float native_width = 1920;
	public float native_height = 1080;
	
	
	public GUIStyle style;
	public GUIStyle buttonStyle;

	
	void OnGUI(){
		float rx = Screen.width / native_width;
		float ry = Screen.height / native_height;
		GUI.matrix = Matrix4x4.TRS(new Vector3 (0,0,0), Quaternion.identity, new Vector3(rx,ry,1));
		

		GUI.Label(new Rect( scoreWidth, scoreHeight + 100, 500, 500), "Snake Prototype: Build 2", style);
		GUI.Label(new Rect( 55, 800, 400,400), " Use Arrow Keys to move Snake!", style);
		
		if(GUI.Button(new Rect( 100, 400, 300, 300), "PLAY", buttonStyle))
			Application.LoadLevel("Arcade Prototype Scene");
			
		
			
	}
}
