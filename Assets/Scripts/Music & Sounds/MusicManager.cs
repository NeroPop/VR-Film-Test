using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    [SerializeField]
    int TrackNumber = 1;

    [SerializeField]
    private float CurrentTime = 0;

    [SerializeField]
    private float TrackLength;

    [SerializeField]
    private bool Paused = false;

    private float ClipTime = 0;


    [Header("Soundtrack Audio")]

    [SerializeField]
    AudioClip Track1;
    [SerializeField]
    AudioClip Track2;
    [SerializeField]
    AudioClip Track3;
    [SerializeField]
    AudioClip Track4;
    [SerializeField]
    AudioClip Track5;
    [SerializeField]
    AudioClip Track6;
    [SerializeField]
    AudioClip Track7;

    public event Action<float> OnUpdate;
    private void Start()
    {

        TrackNumber = 1;
        PlaySong();

    }

    private void Update()
    {
        if (!Paused)
        {
            OnUpdate?.Invoke(Time.deltaTime);
            CurrentTime = CurrentTime + Time.deltaTime;
        }
    }

    IEnumerator Playing()
    {
        AudioSource audio = GetComponent<AudioSource>();

        Debug.Log("Playing Track " + TrackNumber + " Clip Length " + audio.clip.length + " Playing from " + CurrentTime);

        ClipTime = audio.clip.length - CurrentTime;
        yield return new WaitForSeconds(ClipTime);

        if (!Paused)
        {
            if (CurrentTime >= audio.clip.length)
            {
                TrackNumber += 1;
                PlaySong();
                StopCoroutine(Playing());
               // Debug.Log("CorrectLength");
            }
           /* else
            {
                //I Don't know what's causing this but it seems to work anyway since adding it in?
                ClipTime = audio.clip.length - CurrentTime;
                yield return new WaitForSeconds(ClipTime);
                Debug.Log("Something went wrong ClipTime is " + ClipTime + "Current time is " + CurrentTime);
            } */
        }

        else
        {
            Debug.Log("Paused at " + CurrentTime);
        }

    }

    public void PlaySong()
    {
        AudioSource audio = GetComponent<AudioSource>();

        if (TrackNumber == 1)
        {
            audio.clip = Track1;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }

        else if (TrackNumber == 2)
        {
            audio.clip = Track2;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }

        else if (TrackNumber == 3)
        {
            audio.clip = Track3;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }

        else if (TrackNumber == 4)
        {
            audio.clip = Track4;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }

        else if (TrackNumber == 5)
        {
            audio.clip = Track5;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }

        else if (TrackNumber == 6)
        {
            audio.clip = Track6;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }

        else if (TrackNumber == 7)
        {
            audio.clip = Track7;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }
    }

    public void Skip()
    {
        StopCoroutine(Playing());
        TrackNumber += 1;
        PlaySong();
       // Debug.Log("Skipped to Track " + TrackNumber);
    }

    public void Back()
    {
        StopCoroutine(Playing());
        TrackNumber -= 1;
        PlaySong();
       // Debug.Log("Returned to Track " + TrackNumber);
    }

    public void Pause()
    {
        AudioSource audio = GetComponent<AudioSource>();

        StopCoroutine(Playing());
        Paused = true;
        audio.Pause();
    }

    public void Resume()
    {
        AudioSource audio = GetComponent<AudioSource>();

        StartCoroutine(Playing());
        Paused = false;
        audio.UnPause();
    }
}
