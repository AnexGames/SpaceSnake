using UnityEngine;
using System.Collections;

public class changeBlueHead : MonoBehaviour {

	void OnClick(){
		
		PlayerPrefs.SetString("HeadTexture", "BlueCube");		
		
	}
}
