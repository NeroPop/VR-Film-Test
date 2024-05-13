using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    [SerializeField]
    int TrackNumber =1;

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
    private void Start()
    {
       // AudioSource audio = GetComponent<AudioSource>();

        TrackNumber = 1;
        PlaySong();

    }

    IEnumerator Playing()
    {
        AudioSource audio = GetComponent<AudioSource>();

        yield return new WaitForSeconds(audio.clip.length);
        TrackNumber += 1;
        PlaySong();
    }

    public void PlaySong()
    {
        AudioSource audio = GetComponent<AudioSource>();

        if (TrackNumber == 1)
        {
            audio.clip = Track1;
            audio.Play();
            Playing();
            Debug.Log("Playing Track " +  TrackNumber);
        }

        else if (TrackNumber == 2)
        {
            audio.clip = Track2;
            audio.Play();
            Playing();
            Debug.Log("Playing Track " + TrackNumber);
        }

        else if (TrackNumber == 3)
        {
            audio.clip = Track3;
            audio.Play();
            Playing();
            Debug.Log("Playing Track " + TrackNumber);
        }

        else if (TrackNumber == 4)
        {
            audio.clip = Track4;
            audio.Play();
            Playing();
            Debug.Log("Playing Track " + TrackNumber);
        }

        else if (TrackNumber == 5)
        {
            audio.clip = Track5;
            audio.Play();
            Playing();
            Debug.Log("Playing Track " + TrackNumber);
        }

        else if (TrackNumber == 6)
        {
            audio.clip = Track6;
            audio.Play();
            Playing();
            Debug.Log("Playing Track " + TrackNumber);
        }

        else if (TrackNumber == 7)
        {
            audio.clip = Track7;
            audio.Play();
            Playing();
            Debug.Log("Playing Track " + TrackNumber);
        }
    }

    public void Skip()
    {
        TrackNumber += 1;
        PlaySong();
        Debug.Log("Skipped to Track " + TrackNumber);
    }
}
