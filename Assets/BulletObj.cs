using UnityEngine;
using System.Collections;

public class BulletObj : MonoBehaviour {
	public GFGrid grid;
	private Transform cachedTransform;
	public float speed = 1;
	private float sinceLastTick = 0;
	private float nextTick = 0.5f;

	
	// Use this for initialization
	void Start () {
		cachedTransform = this.transform;
		
		if(grid)
			grid.AlignTransform(cachedTransform);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//sinceLastTick += Time.deltaTime;
		
		//if(sinceLastTick > nextTick){
			
	    	iTween.MoveTo(this.gameObject, this.gameObject.transform.position + new Vector3(-1, 0 , 0), 2);
			//this.transform.position += new Vector3(-1, 0, 0);
			
		//	sinceLastTick -= nextTick;
		
		
	}
	
	void OnTriggerEnter(Collider col){
		
		if(col.gameObject.tag == "Player"){
			
			Debug.Log("Hit Player. Your dead.");
			Destroy(col.gameObject);
		}
		
		if(col.gameObject.tag == "Body"){
			
			Debug.Log("Hit Body!");
			
			Destroy(this.gameObject);
		}
		
		if(col.gameObject.tag == "Barrier"){
			
			Debug.Log("Hit Barrier");
			Destroy(this.gameObject); 

		}
	}
	
		
}
