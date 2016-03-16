using UnityEngine;
using System.Collections;

public class EnableCustomize : MonoBehaviour {

	public GameObject _Customize;
	
	void OnClick(){
		_Customize.SetActive(true);	
	}
}
