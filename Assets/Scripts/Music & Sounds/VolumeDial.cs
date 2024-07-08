using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeDial : MonoBehaviour
{
    public AudioSource _AudioSource;

    [SerializeField]
    private float _Volume =1;

    [SerializeField]
    private float _currentStep;

    /// <param name="step">User input.</param>
    public void SetVolume(int step)
    {
        _currentStep = step;

        _Volume =  1 - (_currentStep / 100);

       _AudioSource.volume = _Volume;
    }
}
