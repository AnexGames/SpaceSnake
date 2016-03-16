using UnityEngine;
using System.Collections;

public class _changeGreenBody : MonoBehaviour {

	void OnClick(){
		
		PlayerPrefs.SetString("BodyTexture", "Green");		
		
	}
}
