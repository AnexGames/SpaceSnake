using UnityEngine;
using System.Collections;
using System.Collections.Generic;
	
public class Arrays : MonoBehaviour {
	static public GFGrid movementGrid;
	static private int[] sizeTest; 
	static bool[,] gridTiles;
	static private int[] originSquare;
	static List<int[]> indexList;
	// Use this for initialization
	void Start () {
		movementGrid = GetComponent<GFRectGrid>();
	}
	
	// Update is called once per frame
	void Update () {
		movementGrid = GetComponent<GFRectGrid>();
		SetOriginSquare();
		BuildMatrix();
		SpawnFood();
	}
	
	//Gets x,y size of the grid, and throws the values in the sizeTest array and return 
	static int[,] GridSize(){
		int[,] gridSize = new int[ Mathf.FloorToInt(movementGrid.size.x),  Mathf.FloorToInt(movementGrid.size.y)];
		
		
		
		return gridSize;
	}
	
	//Builds matrix based on GridSize() and sets all values to true
	private void BuildMatrix(){

		int[,] gridSize = GridSize();
			
		//gridTiles = new bool[5, 5] {{0,0,0,0,0}, {0,0,0,0,0}, {0,0,0,0,0}, {0,0,0,0,0}, (0,0,0,0,0}}
		gridTiles = new bool[gridSize.GetLength(0), gridSize.GetLength(1)];
		
		
		
		for(int rows = 0; rows < gridSize.GetLength(0); rows++){
			for(int cols = 0; cols < gridSize.GetLength(1); cols++){
				gridTiles[rows,cols] = true;
				//Debug.Log(gridTiles[rows,cols]);
			}
		}
	
	
	}
	
	
	//check and index open positions
	public void SpawnFood(){
		List<int[]> indexList = new List<int[]>();  // indexes go here from grid
		
		bool[,] levelMatrix = gridTiles;
		
		for(int rows = 0; rows < levelMatrix.GetLength(0); rows++){
			for(int cols = 0; cols < levelMatrix.GetLength(1); cols++){
				if(levelMatrix[rows, cols] == true)
					//indexList.Add (new int[2,2] {{ rows,cols}, {rows,cols}});
					indexList.Add(new int[2] {rows,cols});
					
			}
		}
		
		int listLength = indexList.Count;
		int listIndex = Random.Range(0, listLength);
		
		Vector3 someVector = movementGrid.GridToWorld (new Vector3 (indexList [listIndex][0], indexList [listIndex][1], -0.3f));
		
		
	
	}
	

	//Shoot the matrix array to string
	public static string MatrixToString(){
		string text = "Occupied fields are 1, free fields are 0:\n\n";
		for(int j = gridTiles.GetLength(1)-1; j >= 0; j--){
			for(int i = 0; i < gridTiles.GetLength(0); i++){
				//text = text + (gridTiles[i,j]) + " ";
				text = text + (gridTiles[i,j] ? "0" : "1") + " ";
			}
			text += "\n";
		}
		return text;
	}
	
	//---------------------------------------------------------------------------
	//--------------------------------------------------------------------------
	
	public static void SetOriginSquare(){
		//get the grid coordinates of the box (see GetBoxCoordinates in documentation); we get three coordinates, but we only use X and Y
		//we add 0.1f * Vector3.one to avoid unexpected behaviour for edge cases dues to rounding and float (in)accuracy, we subtract 0.5f * Vector3.one to get whole numbers
		Vector3 box = movementGrid.useCustomRenderRange? movementGrid.NearestBoxG(movementGrid.transform.position + movementGrid.renderFrom + 0.1f * Vector3.one) - 0.5f * Vector3.one:
			movementGrid.NearestBoxG(movementGrid.transform.position - movementGrid.size + 0.1f * Vector3.one) - 0.5f * Vector3.one;
		originSquare = new int[2]{Mathf.RoundToInt(box.x), Mathf.RoundToInt(box.y)};
	}
	
	public static void RegisterSquare(Vector3 vec, bool status){
		//first find the square that belongs to that world position
		int[] square = GetSquare(vec);
		//then set its value
		gridTiles[square[0],square[1]] = status;
		
	}
	
	//takes world coodinates, finds the corresponding square and returns the value of that square. Use it to cheack if a square is forbidden or not
	public static bool CheckSquare(Vector3 vec){
		int[] square = GetSquare(vec);
		return gridTiles[square[0],square[1]];
	}
	
	//takes world coodinates and finds the corresponding square. The result is returned as an int array that contains that square's position in the matrix
	private static int[] GetSquare(Vector3 vec){
		int[] square = new int [2];
		for(int i = 0; i < 2; i++){
			square[i] = Mathf.FloorToInt(movementGrid.NearestBoxG(vec)[i]) - originSquare[i];
		}
		return square;
	}
	
	//GUI function controlling writing out grid matrix
	void OnGUI(){
		
		//GUI.TextArea(new Rect(10, 10, 350, 350),MatrixToString());
	}
		
}
