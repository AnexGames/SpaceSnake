using UnityEngine;
using System.Collections;

public class FlappyBird : MonoBehaviour {
	public float _f = 5.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey("space")){
            GetComponent<Rigidbody>().AddForce(0, 1 * _f, 0 );	
		}
	
	}
}
