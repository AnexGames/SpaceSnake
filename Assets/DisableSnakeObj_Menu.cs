using UnityEngine;
using System.Collections;

public class DisableSnakeObj_Menu : MonoBehaviour {
	public GameObject snakeHolder;
	
	void OnClick(){
		
		snakeHolder.SetActive(false);
	}
}
