using UnityEngine;
using System.Collections;

public class FoodGoalIndicator : MonoBehaviour {
	public UILabel _goal;
	
	// Update is called once per frame
	void Update () {
		_goal.text = GameManager.foodPickedTotal + " / " + 10;
	}
}
