using UnityEngine;
using System.Collections;

public class ChangeRedHead : MonoBehaviour {

	void OnClick(){
		
		PlayerPrefs.SetString("HeadTexture", "RedTexture");		
		
	}
}
