using UnityEngine;
using System.Collections;

public class _changeBlackBody : MonoBehaviour {

	void OnClick(){
		
		PlayerPrefs.SetString("BodyTexture", "Black White");		
		
	}
}
