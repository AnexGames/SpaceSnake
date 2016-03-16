using UnityEngine;
using System.Collections;

public class _changeBlueTexture : MonoBehaviour {

	void OnClick(){
		
		PlayerPrefs.SetString("BodyTexture", "BlueCube");		
		
	}
}
