using UnityEngine;
using System.Collections;

public class _changeRedBlackBody : MonoBehaviour {

	void OnClick(){
		
		PlayerPrefs.SetString("BodyTexture", "RedBlack");		
		
	}
}
