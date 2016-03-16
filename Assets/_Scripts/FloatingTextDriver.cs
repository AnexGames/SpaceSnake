using UnityEngine;
using System.Collections;

public class FloatingTextDriver : MonoBehaviour {
	public GameObject _target;
	public FloatingScore prefab;
	public Transform parent;
	

	
	// Use this for initialization
	public IEnumerator OnClick() {
		
		FloatingScore fs = Instantiate(prefab) as FloatingScore;
		
		Vector3 size = fs.transform.localScale;
		
		fs.SpawnAt(_target, parent, size);
		
		fs.Init(Color.white, "+ " + GameManager.foodScore * ScoreMultiplier.multiplier, _target);
		
		TweenPosition tp = fs.tweenPos;
		TweenAlpha ta = fs.tweenAlpha;

		
		tp.duration = 2.0f;
		fs.Following();
		
		tp.from = fs.transform.localPosition;
		tp.to = tp.from + Vector3.up * 50;

		ta.duration = 2;
		ta.from = 1;
		ta.to = 0;
		
		yield return new WaitForSeconds(3f);
		fs.DestoryMe();
		
	}
}
