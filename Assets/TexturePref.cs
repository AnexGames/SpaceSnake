using UnityEngine;
using System.Collections;

public class TexturePref : MonoBehaviour {
	
	public static Texture bodyTex;
	public static Texture headTex;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		bodyTex = PlayerPrefs.GetString("CurrentBodyTex");
//		headTex = PlayerPrefs.GetString("CurrentHeadTex");
		//this.gameObject.renderer.material.GetTexture(PlayerPrefs.GetString("HeadTexture"));
	
		//this.gameObject.GetComponent<Renderer>().material.GetTexture("Black White");
		//headTex = this.gameObject.GetComponent<Renderer>().material
	//	this.gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", headTex);
		//Texture headTex = (Texture).Resources.Load(PlayerPrefs.GetString("HeadTexture"), typeof(Texture));
		this.gameObject.GetComponent<Renderer>().material.mainTexture = Resources.Load(PlayerPrefs.GetString("HeadTexture"),typeof(Texture2D)) as Texture2D;
	}
}
