using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoSpinner : MonoBehaviour
{
    public float rotationSpeed = 1.0f; // Adjust the speed of rotation

    public void RotateToAngle(Quaternion targetRotation)
    {
        StartCoroutine(RotateCoroutine(targetRotation));
    }

    IEnumerator RotateCoroutine(Quaternion targetRotation)
    {
        Quaternion startRotation = transform.rotation;
        float elapsedTime = 0.0f;

        while (elapsedTime < 1.0f)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime);
            elapsedTime += Time.deltaTime * rotationSpeed;
            yield return null;
        }

        transform.rotation = targetRotation; // Ensure final rotation is exact
    }

    public void Rotation1()
    {
        RotateToAngle(Quaternion.Euler(0, 0, 0));
    }

    public void Rotation2()
    {
        RotateToAngle(Quaternion.Euler(90, 0, 0));
    }

    public void Rotation3()
    {
        RotateToAngle(Quaternion.Euler(180, 0, 0));
    }

    public void Rotation4()
    {
        RotateToAngle(Quaternion.Euler(270, 0, 0));
    }
}
