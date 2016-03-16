/*******************************************************************************************
 *       Author: Lane Gresham, AKA LaneMax
 *         Blog: http://lanemax.blogspot.com/
 *      Version: 2.25
 * Created Date: 12/20/13 
 * Last Updated: 12/20/13
 *  
 *  Description: 
 *  
 *      Allows you to change the time scale for slow motion.
 *      
*******************************************************************************************/
using UnityEngine;
using System.Collections;

public class SceneTimeScale : MonoBehaviour
{
    [Range(0,1f)]
    public float time = 1.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = time;
    }
}
