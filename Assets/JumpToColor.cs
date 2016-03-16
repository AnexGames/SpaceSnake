using UnityEngine;
using System.Collections;

public class JumpToColor : MonoBehaviour {
	
	public GameObject _UIGrid;
	
	void OnClick(){
		//MoveToClosest();
	}
	
//	void MoveToClosest(){
//		float min = float.MaxValue;
//		Transform closest = null;
//		Transform trans = _UIGrid.transform;
//		int index = 0;
//		
//		for (int i = 0, imax = trans.childCount; i < imax; ++i){
//			Transform t = trans.GetChild(i);
//			float sqrDist = Vector3.SqrMagnitude(t.position - pickingPoint);
//
//			if (sqrDist < min)
//			{
//				min = sqrDist;
//				closest = t;
//				index = i;
//			}
//		}
//
//	}
}
