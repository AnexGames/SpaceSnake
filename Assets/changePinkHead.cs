using UnityEngine;
using System.Collections;

public class changePinkHead : MonoBehaviour {

	void OnClick(){
		
		PlayerPrefs.SetString("HeadTexture", "Pink");		
		
	}
}
