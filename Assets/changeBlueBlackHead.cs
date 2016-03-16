using UnityEngine;
using System.Collections;

public class changeBlueBlackHead : MonoBehaviour {

	void OnClick(){
		
		PlayerPrefs.SetString("HeadTexture", "Blueblack Cube");		
		
	}
}
