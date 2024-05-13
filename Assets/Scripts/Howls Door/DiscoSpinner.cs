using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoSpinner : MonoBehaviour
{
    public void Rotation1()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void Rotation2()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    public void Rotation3()
    {
        transform.rotation = Quaternion.Euler(180, 0, 0);
    }

    public void Rotation4()
    {
        transform.rotation = Quaternion.Euler(270, 0, 0);
    }
}
