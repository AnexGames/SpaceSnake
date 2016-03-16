using UnityEngine;
using System.Collections;

public class _changeWhiteBody : MonoBehaviour {

	void OnClick(){
		
		PlayerPrefs.SetString("BodyTexture", "White");		
		
	}
}
