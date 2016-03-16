using UnityEngine;
using System.Collections;

public class changeColorTest : MonoBehaviour {

	void OnClick(){
		//if(!PlayerPrefs.HasKey("HeadTexture")){
			PlayerPrefs.SetString("HeadTexture", "Black White");
	//	}
		
	}
}
