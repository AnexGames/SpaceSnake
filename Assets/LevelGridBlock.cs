using UnityEngine;
using System.Collections;

public class LevelGridBlock : MonoBehaviour {

	public GFGrid grid;
	private Transform cachedTransform;
	
	// Use this for initialization
	void Start() {
		
		cachedTransform = this.transform;
	
		grid.AlignTransform(cachedTransform, false);
	
	
			
	}
	
}