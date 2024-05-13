using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [Header("Angle of rotation")]
    [Tooltip("Angle of rotation at each increment")]
    [SerializeField]
    float RotationAngle;


    [Header("Axis")]
    [Tooltip("Local axis of rotation")]

    [SerializeField]
    bool XAxis;

    [SerializeField]
    bool YAxis;

    [SerializeField]
    bool ZAxis;

   public void RotateObject()
    {
        if (XAxis)
        {
            transform.Rotate(RotationAngle, 0, 0);
        }
        else if (YAxis)
        {
            transform.Rotate(0, RotationAngle, 0);
        }
        else if (ZAxis)
        {
            transform.Rotate(0, 0, RotationAngle);
        }
        else
        {
            Debug.Log("Error! Select a Axis of Rotation!");
        }
    }

}
