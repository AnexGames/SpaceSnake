using UnityEngine;
using System.Collections;

public class Arcade_Load : MonoBehaviour {
	public GameObject blackFade;
	public static bool _arcade;
	
	void OnClick() {
	//	NGUITools.SetActive(blackFade, true);
		
		NGUITools.AddChild(this.gameObject, blackFade);
		_arcade = true;
		//Application.LoadLevel(1);	
	}
}
