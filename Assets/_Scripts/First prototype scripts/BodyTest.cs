using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BodyTest : MonoBehaviour {
	
	public GameObject snakeBody;
	
	public static List <GameObject> snakeUpdate = new List<GameObject>();
	
	
	
	public float offset = 3.0f;  //distance between body parts 
	
	void Start(){

		
		snakeUpdate.Add(this.gameObject);
		
		for(int i = 0; i < 3 ; i++){
			
			GameObject h = Instantiate(snakeBody, new Vector3(0, 0, -3), Quaternion.identity)as GameObject;
			snakeUpdate.Add(h);
		}

		
	}
	
	void Update(){
		
		DrawSnake();
	}
	
	
	public static void DrawSnake(){
		
		for (int i = (snakeUpdate.Count - 1); i >0; i--){
			
			snakeUpdate[i].transform.position = snakeUpdate[i - 1].transform.position;
		}
	}
}
	//Updates body position! 
//	void DrawSnake(){
//		
//		//for every snake piece in snake body array
//		for(int i = (snakeUpdatePos.Length - 1); i > 0; i--){
//			
//			//take the position and update the position with snake piece in front
//			snakeUpdatePos[i].transform.position = snakeUpdatePos[i-1].transform.position;
//		}
//	}


//		for(int i = 0; i < snakeUpdatePos.Length; i++){
//			
//			Instantiate(snakeBody, new Vector3(0,0,-3), Quaternion.identity);
//			offset += 0.1f;
//		}

//snakeUpdatePos = new GameObject[3];
//snakeUpdatePos[0] = this.gameObject;
//public GameObject[] snakeUpdatePos;