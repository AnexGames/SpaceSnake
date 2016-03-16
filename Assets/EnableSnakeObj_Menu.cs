using UnityEngine;
using System.Collections;

public class EnableSnakeObj_Menu : MonoBehaviour {
	public GameObject snakeHolder;
	
	void OnClick(){
		
		snakeHolder.SetActive(true);
	}
}
