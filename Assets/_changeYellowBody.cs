using UnityEngine;
using System.Collections;

public class _changeYellowBody : MonoBehaviour {

	void OnClick(){
		
		PlayerPrefs.SetString("BodyTexture", "Yellow");		
		
	}
}
