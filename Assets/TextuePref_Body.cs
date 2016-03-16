using UnityEngine;
using System.Collections;

public class TextuePref_Body : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			
		this.gameObject.GetComponent<Renderer>().material.mainTexture = Resources.Load(PlayerPrefs.GetString("BodyTexture"), typeof(Texture)) as Texture;
	}
}
