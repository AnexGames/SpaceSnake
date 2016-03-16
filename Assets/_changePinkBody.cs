using UnityEngine;
using System.Collections;

public class _changePinkBody : MonoBehaviour {

	void OnClick(){
		
		PlayerPrefs.SetString("BodyTexture", "Pink");		
		
	}
}
