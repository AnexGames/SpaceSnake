/*******************************************************************************************
 *       Author: Lane Gresham, AKA LaneMax
 *         Blog: http://lanemax.blogspot.com/
 *      Version: 2.25
 * Created Date: 12/20/13 
 * Last Updated: 12/20/13
 *  
 *  Description: 
 *  
 *      Allows you to see the Circular Gravity Force in EditMode/Gizmos.
 *      
 *  How To Use:
 *  
 *      Simply drag and drop / assign this script to whatever GameObject that has the 
 *      componet CircularGravity, then you should see the CircularGravity in EditMode.
 * 
 *  Inputs:
 * 
 *      none
 *          
*******************************************************************************************/
using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CircularGravityGizmos : MonoBehaviour
{
    private CircularGravity circularGravity;

    void Update()
    {
        circularGravity = this.GetComponent<CircularGravity>();

        if (circularGravity != null)
        {
            DrawGravityForceGizmos();
        }
    }

    //Draws effected area by forces with debug draw line, so you can see it in Gizmos
    private void DrawGravityForceGizmos()
    {
        //Circular Gravity Force Transform
        Transform cgfTran = this.transform;

        Color DebugGravityLineColor;

        if (circularGravity.forcePower == 0)
            DebugGravityLineColor = Color.white;
        else if (circularGravity.forcePower > 0)
            DebugGravityLineColor = Color.green;
        else
            DebugGravityLineColor = Color.red;

        //Renders type outline
        switch (circularGravity.shape)
        {
            case CircularGravity.Shape.Sphere:

                Debug.DrawLine(cgfTran.position + ((cgfTran.rotation * Vector3.up) * circularGravity.sizeProperties.size), cgfTran.position, DebugGravityLineColor);
                Debug.DrawLine(cgfTran.position + ((cgfTran.rotation * Vector3.down) * circularGravity.sizeProperties.size), cgfTran.position, DebugGravityLineColor);
                Debug.DrawLine(cgfTran.position + ((cgfTran.rotation * Vector3.left) * circularGravity.sizeProperties.size), cgfTran.position, DebugGravityLineColor);
                Debug.DrawLine(cgfTran.position + ((cgfTran.rotation * Vector3.right) * circularGravity.sizeProperties.size), cgfTran.position, DebugGravityLineColor);
                Debug.DrawLine(cgfTran.position + ((cgfTran.rotation * Vector3.forward) * circularGravity.sizeProperties.size), cgfTran.position, DebugGravityLineColor);
                Debug.DrawLine(cgfTran.position + ((cgfTran.rotation * Vector3.back) * circularGravity.sizeProperties.size), cgfTran.position, DebugGravityLineColor);

                break;

            case CircularGravity.Shape.Capsule:

                Debug.DrawLine(cgfTran.position + ((cgfTran.rotation * Vector3.up) * circularGravity.sizeProperties.capsuleRadius), cgfTran.position, DebugGravityLineColor);
                Debug.DrawLine(cgfTran.position + ((cgfTran.rotation * Vector3.down) * circularGravity.sizeProperties.capsuleRadius), cgfTran.position, DebugGravityLineColor);
                Debug.DrawLine(cgfTran.position + ((cgfTran.rotation * Vector3.left) * circularGravity.sizeProperties.capsuleRadius), cgfTran.position, DebugGravityLineColor);
                Debug.DrawLine(cgfTran.position + ((cgfTran.rotation * Vector3.right) * circularGravity.sizeProperties.capsuleRadius), cgfTran.position, DebugGravityLineColor);

                Vector3 endPointLoc = cgfTran.position + ((cgfTran.rotation * Vector3.forward) * circularGravity.sizeProperties.size);

                Debug.DrawLine(cgfTran.position, endPointLoc, DebugGravityLineColor);

                Debug.DrawLine(endPointLoc + ((cgfTran.rotation * Vector3.up) * circularGravity.sizeProperties.capsuleRadius), endPointLoc, DebugGravityLineColor);
                Debug.DrawLine(endPointLoc + ((cgfTran.rotation * Vector3.down) * circularGravity.sizeProperties.capsuleRadius), endPointLoc, DebugGravityLineColor);
                Debug.DrawLine(endPointLoc + ((cgfTran.rotation * Vector3.left) * circularGravity.sizeProperties.capsuleRadius), endPointLoc, DebugGravityLineColor);
                Debug.DrawLine(endPointLoc + ((cgfTran.rotation * Vector3.right) * circularGravity.sizeProperties.capsuleRadius), endPointLoc, DebugGravityLineColor);

                break;

            case CircularGravity.Shape.RayCast:

                Debug.DrawLine(cgfTran.position + ((cgfTran.rotation * Vector3.forward) * circularGravity.sizeProperties.size), cgfTran.position, DebugGravityLineColor);

                break;
        }
    }
}