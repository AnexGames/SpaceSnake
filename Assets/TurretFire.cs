using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretFire : MonoBehaviour {
	public GFRectGrid grid;
	private Transform cachedTransform;
	
	public List<GameObject> spawnPoint = new List<GameObject>();
	
	public float tickTime = 1;
	private float sinceLastTick = 0;
	
	public GameObject bullet;
	
	void Start () {
		cachedTransform = transform;
		
		if(grid)
			grid.AlignTransform(cachedTransform);
		
		foreach(Transform child in transform){
			
			spawnPoint.Add(child.gameObject);
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		sinceLastTick += Time.deltaTime;
		
		if(sinceLastTick > tickTime){
			
			Shoot ();
			sinceLastTick -= tickTime;
	
		}	
	}
	
	void Shoot() {
		
		for(int i = 0; i < spawnPoint.Count; i++){
		
			Instantiate(bullet, spawnPoint[i].transform.position, transform.rotation);
		
		}
	
	}
}
