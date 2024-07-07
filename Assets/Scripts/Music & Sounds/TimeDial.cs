using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeDial : MonoBehaviour
{
    public float RotationSpeed = 1;
    public UnityEvent StepUpdate;
    public bool Grabbed;

    [SerializeField]
    private float _currentStep;
    [SerializeField]
    private float CurrentAngle;

    private void Update()
    {
        if (!Grabbed)
        {
            _currentStep = MusicManager.TimePercent;
            CurrentAngle = (float)(_currentStep * 1.8);

            RotateToAngle(Quaternion.Euler(CurrentAngle, 90, 0));
        }
    }

    /// <param name="step">User input.</param>
    public void SetStep(int step)
    {
        _currentStep = step;

        MusicManager.TimePercent = _currentStep;

        StepUpdate.Invoke();
    }

    public void ResetDial()
    {
        RotateToAngle(Quaternion.Euler(0, 90, 0));
        CurrentAngle = 0;
        _currentStep = 0;
    }

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
            elapsedTime += Time.deltaTime * RotationSpeed;
            yield return null;
        }

        transform.rotation = targetRotation; // Ensure final rotation is exact
    }

    public void ToggleGrab()
    {
        if (Grabbed)
        {
            Grabbed = false;
        }
        else if (!Grabbed)
        {
            Grabbed = true;
        }
    }
}
