using UnityEngine;
using System.Collections;

public class FoodHelperScript : MonoBehaviour {


	public GameObject foodClone;

	
	
	// Use this for initialization
	
	void Start () {
		
		//Vector3 position = new Vector3(Random.Range(-18.3f,18.6f), Random.Range (-13.0f, 14.0f), -0.6f);
		Vector3 position = new Vector3(Random.Range(-11.5f,11.5f), Random.Range (-11.0f, 11.0f), -0.6f);
		
		GameObject clone = Instantiate (foodClone, position, transform.rotation)as GameObject;
		clone.name = "food";
		Destroy(gameObject);
	
	}
	
}
	
	
