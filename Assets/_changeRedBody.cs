using UnityEngine;
using System.Collections;

public class _changeRedBody : MonoBehaviour {

	void OnClick(){
		
		PlayerPrefs.SetString("BodyTexture", "RedTexture");		
		
	}
}
