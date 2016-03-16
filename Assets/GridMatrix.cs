using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridMatrix : MonoBehaviour {
	public static bool[,] allowedTiles;
	private GFRectGrid movementGrid;
	private List<int[,]> gridMatrix;
	
	// Use this for initialization
	void Start () {
		movementGrid = GetComponent<GFRectGrid>();
	}
	
	// Update is called once per frame
	void Update () {
		BuildMatrix();
		SetMatrixSize();
		MatrixToString();
	}
	
	
	private int[] SetMatrixSize(){
		int[] size = new int[2];
		for(int i = 0; i < 2; i++){
			//get the distance between both ends (in world units), divide it by the spacing (to get grid units) and round down to the nearest integer
			size[i] = movementGrid.useCustomRenderRange? Mathf.FloorToInt(Mathf.Abs(movementGrid.renderFrom[i] - movementGrid.renderTo[i]) / movementGrid.spacing[i]):
			2 * Mathf.FloorToInt(movementGrid.size[i] / movementGrid.spacing[i]);
			
		}
		return size;
	}
	
	public void BuildMatrix(){
		//amount of rows and columns, either based on size or rendering range (first entry rows, second one columns)
		int[] size = SetMatrixSize();
						
		//build a default matrix
		allowedTiles = new bool[size[0], size[1]];
		//set all entries to true
		for(int i = 0; i < size[0]; i++){
			for( int j = 0; j < size[1]; j++){
				allowedTiles[i,j] = true;
			}
		}
	}
	
	public static string MatrixToString(){
		string text = "Occupied fields are 1, free fields are 0:\n\n";
		for(int j = allowedTiles.GetLength(1)-1; j >= 0; j--){
			for(int i = 0; i < allowedTiles.GetLength(0); i++){
				text = text + (allowedTiles[i,j] ? "0" : "1") + " ";
			}
			text += "\n";
		}
		return text;
	}
	
//		}
//					
//		//Debug.Log(gridMatrix[9]);
//	}
//	
				
		
	void OnGUI(){
		GUI.TextArea (new Rect (10, 10,500,500), MatrixToString());
	}	
		
	
	
}
