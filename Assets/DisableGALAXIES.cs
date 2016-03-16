using UnityEngine;
using System.Collections;

public class DisableGALAXIES : MonoBehaviour {
	public GameObject _p;
	
	void OnClick(){
		NGUITools.SetActive(_p, false);	
	}
}
