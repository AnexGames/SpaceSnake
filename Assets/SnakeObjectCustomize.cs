using UnityEngine;
using System.Collections;

public class SnakeObjectCustomize : MonoBehaviour {
	public UIPlayAnimation _main;
	public UIPlayAnimation _customize;
	public bool isClicked = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isClicked == true){
			_main.playDirection = AnimationOrTween.Direction.Toggle;
			_customize.playDirection = AnimationOrTween.Direction.Toggle;
			
			isClicked = false;
		}
	}
	
	void OnClick(){
		isClicked = true;
	
	}
}
