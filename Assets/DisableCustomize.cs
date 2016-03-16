using UnityEngine;
using System.Collections;

public class DisableCustomize : MonoBehaviour {
	public GameObject _Customize;
	
	void OnClick(){
		_Customize.SetActive(false);	
	}
}
