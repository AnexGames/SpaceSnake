using UnityEngine;
using System.Collections;

public class MazeGalaxy_Selector : MonoBehaviour {
	public GameObject blackFade;
	
	
	void OnClick(){
		
		NGUITools.AddChild(this.gameObject, blackFade);
		Arcade_Load._arcade = false;
		
		
		
	}
}
