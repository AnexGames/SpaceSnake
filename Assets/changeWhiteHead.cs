using UnityEngine;
using System.Collections;

public class changeWhiteHead : MonoBehaviour {

	void OnClick(){
		
		PlayerPrefs.SetString("HeadTexture", "White");		
		
	}
}
