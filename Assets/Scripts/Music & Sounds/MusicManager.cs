using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]

public class ReadOnlyAttribute : PropertyAttribute { }
public class MusicManager : MonoBehaviour
{
    [Header("Soundtrack Audio")]

    //Audio to be used in the playlist
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
    [SerializeField]
    AudioClip Track8;
    [SerializeField]
    AudioClip Track9;
    [SerializeField]
    AudioClip Track10;
    [SerializeField]
    AudioClip Track11;
    [SerializeField]
    AudioClip Track12;
    [SerializeField]
    AudioClip Track13;
    [SerializeField]
    AudioClip Track14;
    [SerializeField]
    AudioClip Track15;
    [SerializeField]
    AudioClip Track16;
    [SerializeField]
    AudioClip Track17;
    [SerializeField]
    AudioClip Track18;
    [SerializeField]
    AudioClip Track19;
    [SerializeField]
    AudioClip Track20;
    [SerializeField]
    AudioClip Track21;
    [SerializeField]
    AudioClip Track22;
    [SerializeField]
    AudioClip Track23;
    [SerializeField]
    AudioClip Track24;
    [SerializeField]
    AudioClip Track25;
    [SerializeField]
    AudioClip Track26;


    [Header("Music Information")]

    [ReadOnly]
    [SerializeField]
    int TrackNumber = 1;

    [ReadOnly]
    [SerializeField]
    private float CurrentTime = 0;

    [ReadOnly]
    [SerializeField]
    private float TrackLength;

    [ReadOnly]
    [SerializeField]
    private bool Shuffle = false;

    [ReadOnly]
    [SerializeField]
    private bool Paused = false;

    private float ClipTime = 0;
    private int PrevTrack;

    //Tells unity what onUnpdate is because it's dumb
    public event Action<float> OnUpdate;
    private void Start()
    {
        //Starts playing the first song.
        //If it's shuffled then the track is random, if not then it sets the track to 1
        if (!Shuffle)
        {
            TrackNumber = 1;
            PlaySong();
        }

        else if (Shuffle)
        {
            TrackNumber = Random.Range(1, 27);
            PlaySong();
        }
    }

    private void Update()
    {
        //Keeps track of time so we know how far we are into the song
        if (!Paused)
        {
            OnUpdate?.Invoke(Time.deltaTime);
            CurrentTime = CurrentTime + Time.deltaTime;
        }
    }

    IEnumerator Playing()
    {
        //Get's a reference for the AudioSource and displays in the console what song is playing, how long it is and where we are starting from
        AudioSource audio = GetComponent<AudioSource>();
        Debug.Log("Playing Track " + TrackNumber + " Song Length " + audio.clip.length.ToString("F2") + " Playing from " + CurrentTime.ToString("F2"));

        //Figures out how long is left of the audio clip and then waits until it's finished before continuing
        ClipTime = audio.clip.length - CurrentTime;
        yield return new WaitForSeconds(ClipTime);

        //Checks if the music is paused
        if (!Paused)
        {
            //If the music isn't shuffled it saves the current track (incase it gets put on shuffle) and Increases the track number before beggining the next track
            //Also checks that the clip has definitely finished playing before starting the next song
            if (!Shuffle)
            {
                if (CurrentTime >= audio.clip.length)
                {
                    PrevTrack = TrackNumber;
                    TrackNumber += 1;
                    PlaySong();
                    StopCoroutine(Playing());
                }
            }

            //If the music is on shuffle, it calls the Shuffled function which saves the current Track as the previous one and plays a random track next
            //Also checks that the clip has definitely finished playing before starting the next song
            else if (Shuffle)
            {
                if (CurrentTime >= audio.clip.length)
                {
                    Shuffled();
                    StopCoroutine(Playing());
                }
            }

        }
 
        else
        {
            //Insert here what happens when the music has been paused for longer than the song. Nothing needed for pause to work as intended
        }

    }

    public void PlaySong()
    {
        //Get's a reference for the AudioSource
        AudioSource audio = GetComponent<AudioSource>();

        //Checks the current track number and Plays the relevant track
        //Also resets the time to 0 and gets the Length of the track
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

        else if (TrackNumber == 8)
        {
            audio.clip = Track8;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }
        else if (TrackNumber == 9)
        {
            audio.clip = Track9;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }
        else if (TrackNumber == 10)
        {
            audio.clip = Track10;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }
        else if (TrackNumber == 11)
        {
            audio.clip = Track11;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }
        else if (TrackNumber == 12)
        {
            audio.clip = Track12;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }
        else if (TrackNumber == 13)
        {
            audio.clip = Track13;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }
        else if (TrackNumber == 14)
        {
            audio.clip = Track14;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }
        else if (TrackNumber == 15)
        {
            audio.clip = Track15;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }
        else if (TrackNumber == 16)
        {
            audio.clip = Track16;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }
        else if (TrackNumber == 17)
        {
            audio.clip = Track17;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }
        else if (TrackNumber == 18)
        {
            audio.clip = Track18;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }
        else if (TrackNumber == 19)
        {
            audio.clip = Track19;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }
        else if (TrackNumber == 20)
        {
            audio.clip = Track20;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }
        else if (TrackNumber == 21)
        {
            audio.clip = Track21;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }
        else if (TrackNumber == 22)
        {
            audio.clip = Track22;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }
        else if (TrackNumber == 23)
        {
            audio.clip = Track23;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }
        else if (TrackNumber == 24)
        {
            audio.clip = Track24;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }
        else if (TrackNumber == 25)
        {
            audio.clip = Track25;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }
        else if (TrackNumber == 26)
        {
            audio.clip = Track26;
            TrackLength = audio.clip.length;
            CurrentTime = 0;
            audio.Play();
            StartCoroutine(Playing());
        }
    }

    public void Skip()
    {
        //Plays the next song
        //If shuffled, it calls the shuffle function, if not shuffled it increases the track number and then plays the next song
        if (!Shuffle)
        {
            StopCoroutine(Playing());
            PrevTrack = TrackNumber;
            TrackNumber += 1;
            PlaySong();
        }

        else if (Shuffle)
        {
            StopCoroutine(Playing());
            Shuffled();
        }
    }

    public void Back()
    {
        //Plays the previous song
        //If shuffled it plays the previous track number, if not shuffled it simply goes back 1 track
        if (!Shuffle)
        {
            StopCoroutine(Playing());
            TrackNumber -= 1;
            PlaySong();
        }

        else if (Shuffle)
        {
            StopCoroutine(Playing());
            TrackNumber = PrevTrack;
            PlaySong();
        }

    }

    public void Pause()
    {
        //Gets a reference to the audio source
        AudioSource audio = GetComponent<AudioSource>();

        //Pauses the audio and stops the coroutine from playing the next track. Also sends a message to the console displaying what time it paused at
        StopCoroutine(Playing());
        Paused = true;
        audio.Pause();
        Debug.Log("Paused at " + CurrentTime.ToString("F2"));
    }

    public void Resume()
    {
        //Gets a reference to the audio source
        AudioSource audio = GetComponent<AudioSource>();

        //Starts the coroutine again and unpauses the audio
        StartCoroutine(Playing());
        Paused = false;
        audio.UnPause();
    }

    private void Shuffled()
    {
        //Saves the current track as the previous track before randomising the current track
        PrevTrack = TrackNumber;
        TrackNumber = Random.Range(1, 27);

        //Checks to make sure you can't hear the same song twice in a row
        if (TrackNumber == PrevTrack)
        {
            Shuffled();
        }

        else if (TrackNumber != PrevTrack)
        {
            PlaySong();
        }
    }

    public void ToggleShuffle()
    {
        //Enables or disables shuffle depending on what state it was on before
        if (!Shuffle)
        {
            Shuffle = true;
        }

        else if (Shuffle)
        {
            Shuffle = false;
        }
    }
}
