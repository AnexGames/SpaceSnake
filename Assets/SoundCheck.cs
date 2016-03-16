using UnityEngine;
using System.Collections;

public class SoundCheck : MonoBehaviour {
	public GameObject soundMute;
	
	void OnClick(){
		NGUITools.SetActive(this.gameObject, false);
		NGUITools.SetActive(soundMute, true);		
	}
	void OnActivate(bool isChecked){
		
		if(isChecked){
				
			Debug.Log("mute sound");
			
		}
	}
}
