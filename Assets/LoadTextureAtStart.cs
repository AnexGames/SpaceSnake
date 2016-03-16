using UnityEngine;
using System.Collections;

public class LoadTextureAtStart : MonoBehaviour {

	void Awake(){
		
		this.gameObject.GetComponent<Renderer>().material.mainTexture = Resources.Load(PlayerPrefs.GetString("BodyTexture"), typeof(Texture)) as Texture;	
	}
}
