using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	public GFGrid grid;
	private Transform cachedTransform;
	public GameObject bullet;
	public Transform bulletSpawn;
	
	public float tickTime = 1f;
	private float sinceLastTick = 0f;
	
	// Use this for initialization
	void Start () {
		cachedTransform = transform;
		
		if(grid)
			grid.AlignTransform(cachedTransform);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		sinceLastTick += Time.deltaTime;
		
		if(sinceLastTick > tickTime){
			Shoot ();
			
			sinceLastTick -= tickTime;
			
		}
	}
	
	public void Shoot(){ 
		
		GameObject _bullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
		
	}
	
//	public void MoveBullet(GameObject _bul, int _dir){
//		
//		_bul.transform.position += new Vector3( bulletSpawn.transform.position.x + _dir, bulletSpawn.transform.position, bulletSpawn.transform.position.z);
//		
//	}
//	
	
}
