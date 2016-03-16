using UnityEngine;
using System.Collections;

public class EnableGalaxies : MonoBehaviour {

	public GameObject _p;
	
	void OnClick(){
		NGUITools.SetActive(_p, true);	
	}
}
