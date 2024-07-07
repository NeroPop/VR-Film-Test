using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VolumeDial : MonoBehaviour
{
    public AudioSource _AudioSource;

    [SerializeField]
    private float _Volume;

    /// <summary>Sets the snap amount based on user input.</summary>
    /// <param name="step">User input.</param>
    public void SetVolume(int step)
    {
        _Volume = (step / 180) * 100;

        _AudioSource.volume = _Volume;
    }
}
