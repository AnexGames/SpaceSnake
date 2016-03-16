using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameex : MonoBehaviour {
	
	public float tickTime = 1f;
	private Vector3 direction = new Vector3(1,0,0);
	private float sinceLastTick = 0f;
	public GameObject cube;
	public int maxLength = 5;
	private List<GameObject> tail = new List<GameObject>();
    public bool pause = false;
 
   
 
    void Start()
    {
        //Time.timeScale = 0;
 
    }
    void OnTriggerEnter(Collider c)
    {
        Debug.Log("Trigger");
        if (c.name == "SnakeCube(Clone)")
        {
            Debug.Log("YOU LOST");
           
        }
 
    }
	// Update is called once per frame
	void Update () {
        if (!pause)
        {
            //print("Time.timeScale" + Time.timeScale + " deltatima:" + Time.deltaTime);
            sinceLastTick += Time.deltaTime;
            if (sinceLastTick > tickTime)
            {
                Move();
                sinceLastTick -= tickTime;
            }
			
			if(Input.GetButtonDown("left"))
				direction = new Vector3(-1,0,0);
			else if(Input.GetButtonDown("up"))
				direction = new Vector3(0,1,0);
			else if(Input.GetButtonDown("right"))
				direction = new Vector3(1,0,0);
			else if(Input.GetButtonDown("down"))
				direction = new Vector3(0,-1,0);

        }
	}
	
	void Move()
	{
		
		GameObject instance = Instantiate(cube.gameObject, transform.position,transform.rotation) as GameObject;
		tail.Add (instance);
		transform.position+= direction;
//        if (transform.position.x >= 20) transform.position-=new Vector3(20,0);
//        if (transform.position.x < 0) transform.position += new Vector3(20, 0);
//        if (transform.position.y >= 10) transform.position -= new Vector3(0, 10);
//        if (transform.position.y < 0) transform.position += new Vector3(0, 10);
 
		if(tail.Count>maxLength)
		{
			//Debug.Log (">");
			Destroy(tail[0]);
			tail.RemoveAt(0);
		}
	}
	


 
    public void ClearTail()
    {
        for (int i = 0; i < tail.Count; i++)
        {
            Destroy(tail[i]);
        }
        tail.RemoveRange(0, tail.Count);
    }
 
}