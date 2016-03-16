using UnityEngine;
using System.Collections;

public class WarningArrows : MonoBehaviour {
	public GameObject arrowContainer;
	public static bool arrowBool;
	// Use this for initialization
	void Start () {
		
		NGUITools.SetActive(arrowContainer, false);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(GameManager.foodPickedTotal == 10 || FinalMazePickup.mazeTrigger == true){
		
			StartCoroutine(ArrowIndicator());
		}
		
	}
	
	public IEnumerator ArrowIndicator(){
		
		//while(WarningArrows.arrowBool == true){
			NGUITools.SetActive (arrowContainer, true);
			yield return new WaitForSeconds(3);
			NGUITools.SetActive (arrowContainer, false);
	//	}
			
			
	}
}
