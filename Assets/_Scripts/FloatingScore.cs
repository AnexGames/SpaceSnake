using UnityEngine;
using System.Collections;

public class FloatingScore : MonoBehaviour {
	//change the color
	//spawn at a specific spot on the screen
	//pass in a string to be displayed
	//follow the gameobject on the screen 
	//turn label on/off
	//float upward for x seconds then destroy 
	//change the font
	
	
	//Getting a reference to our UILabel through GetComponent in Awake()
	private UILabel _lbl;
	private bool _active;
	private Vector3 pos;
	
	public GameObject target;
	public Camera worldCamera;
	public Camera guiCamera;
	
	private Transform _t;
	
	//call upon start
	void Awake() {
		
		_t = transform;
		guiCamera = NGUITools.FindCameraForLayer (gameObject.layer);
		_lbl = GetComponent<UILabel>();
		
		if( _lbl == null ){
			Debug.LogError(" Could not find UILabel for floating text ");
		}
	}

	//this manages position of target 
	public void Following(){
	
		//Set GameObject target from worldspace to viewport space and store position in pos var
		pos = worldCamera.WorldToViewportPoint( target.transform.position );
		
		//Set pos var from viewport to worldspace 
		pos = guiCamera.ViewportToWorldPoint( pos );
		
		//set the z to keep withing NGUI viewport
		pos.z = 0;
		
		_t.position = pos;
	
	}

	public Color TextColor {
		get { return _lbl.color; }
		set { _lbl.color = value; }	
	}
	
	public string GetText {
		get { return _lbl.text; }
		set {_lbl.text = value; }
	}
	
	public bool Active { 
		get { return _active; }
		set { _active = value; }
	}
	
	public Vector3 Size {
		get { return _lbl.transform.localScale; }
		set { _lbl.transform.localScale = value; }
	}
	
	public GameObject Target {
		get { return target; }
		set { 
			target = value; 
			worldCamera = NGUITools.FindCameraForLayer (target.layer);
		}
	}
	
	public void Init(Color _clr, string _str, GameObject _go) {
		TextColor = _clr;
		GetText = _str;
		Target = _go;
	
		
	}
	
	public void SpawnAt(GameObject target, Transform parent, Vector3 size){
		Target = target;
		_t.parent = parent;
		Size = size;
		
			
	}
	
	//Only use this when you instantiate another object in floating driver script
	public void DestoryMe(){
		Destroy(gameObject);
	}
	
	
	//This is used for tweening the score. We make sure we have the tweenposition component
	public TweenPosition tweenPos {
		get{
			TweenPosition tp = GetComponent<TweenPosition>();
			
			if(tp == null)
				tp = gameObject.AddComponent<TweenPosition>();
			
			return tp;
			
		}
	}
	
	public TweenAlpha tweenAlpha { 
		get{
			TweenAlpha ta = GetComponent<TweenAlpha>();
			
			if(ta == null)
				ta = gameObject.AddComponent<TweenAlpha>();
			return ta;
		}
	}
}
