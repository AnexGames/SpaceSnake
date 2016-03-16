using UnityEngine;
using System.Collections;

public class ButtonTest_Snake : MonoBehaviour {
	public static Vector3 _dir;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick(){
			
		_dir = new Vector3(0,1,0);
		
	}
}
