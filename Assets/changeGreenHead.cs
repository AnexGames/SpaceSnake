using UnityEngine;
using System.Collections;

public class changeGreenHead : MonoBehaviour {

	void OnClick(){
		
		PlayerPrefs.SetString("HeadTexture", "Green1Blackborder");		
		
	}
}
