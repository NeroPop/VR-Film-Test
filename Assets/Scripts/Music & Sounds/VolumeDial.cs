using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeDial : MonoBehaviour
{
    public AudioSource _AudioSource;

    [SerializeField]
    public float _Volume;

    [SerializeField]
    private float _currentStep;

    private void Start()
    {
        _Volume = 1;
    }

    /// <param name="step">User input.</param>
    public void SetVolume(int step)
    {
        _currentStep = step;

        _Volume = _currentStep / 100;

       _AudioSource.volume = _Volume;
    }

    private void Update()
    {
        _AudioSource.volume = _Volume;
    }
}
