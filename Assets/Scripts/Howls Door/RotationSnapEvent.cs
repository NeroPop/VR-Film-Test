using HexabodyVR.PlayerController;
using UnityEngine;
using UnityEngine.Events;

public class RotationSnapEvent : MonoBehaviour
{
    [Header("SnapEvents")]

    [SerializeField]
    [Tooltip("0 Degrees Rotation")]
    private UnityEvent Rot1;

    [SerializeField]
    [Tooltip("90 Degrees Rotation")]
    private UnityEvent Rot2;

    [SerializeField]
    [Tooltip("180 Degrees Rotation")]
    private UnityEvent Rot3;

    [SerializeField]
    [Tooltip("270 Degrees Rotation")]
    private UnityEvent Rot4;

    private void Start()
    {
        Rot1.Invoke();
    }

    /// <summary>Sets the snap amount based on user input.</summary>
    /// <param name="step">User input.</param>
    public void SetSnapAmount(int step)
    {
        if (step == 0)
        {
            Rot1.Invoke();
            //Debug.Log("Rot1");
        }
        else if (step == 1)
        {
            Rot2.Invoke();
           // Debug.Log("Rot2");
        }
        else if (step == 2)
        {
            Rot3.Invoke();
           // Debug.Log("Rot3");
        }
        else if (step == 3)
        {
            Rot4.Invoke();
           // Debug.Log("Rot4");
        }

    }
}
