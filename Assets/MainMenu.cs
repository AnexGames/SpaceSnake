using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	
	public IEnumerator LoadAfterAudio(){
		yield return new WaitForSeconds(1.0f);
		
		Application.LoadLevel(1);
	}
	
	void OnClick(){
		StartCoroutine(LoadAfterAudio());
		
	}
}
