using UnityEngine;
using System.Collections;

public class testing : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Test1(){
		
		iMove moveScript = gameObject.GetComponent<iMove>();
		moveScript.onStart = true;
		moveScript.Stop();
		iTween.Stop ();
		Debug.Log("hello");
	}
	
	void Test2(){
		iMove moveScript = gameObject.GetComponent<iMove>();
		moveScript.Stop();
		Debug.Log("Hello22");
	}
}
