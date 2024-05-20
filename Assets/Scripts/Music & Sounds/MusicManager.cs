using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]

public class ReadOnlyAttribute : PropertyAttribute { }
public class MusicManager : MonoBehaviour
{
    [Header("Soundtrack Audio")]

    [SerializeField]
    private AudioClip[] Tracks;

    //Audio to be used in the playlist
  /*  [SerializeField]
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
    AudioClip Track26; */

    [Header("Display Elements")]

    //Texts to be displayed in UI
    public TMP_Text DisplayName;
    public TMP_Text DisplayTime;
    public TMP_Text DisplayRemaining;
    public Slider DisplayProgress;
    public Slider audioSlider;
    public GameObject PauseButton;
    public GameObject ResumeButton;

    [Header("Music Information")]

    //Displays the music informaiton in the inspector. All either read only or private
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

    [ReadOnly]
    [SerializeField]
    private bool isDragging = false;

    //Only used in the script
    private float ClipTime = 0;
    private int PrevTrack;
    private float displayseconds;
    private float displayminutes;
    private float progress;
    private float remaining;
    private float remainingseconds;
    private float remainingminutes;
    private bool dragged = false;


    //Tells unity what onUnpdate is because it's dumb
    public event Action<float> OnUpdate;
    private void Start()
    {
        //Starts playing the first song.
        //If it's shuffled then the track is random, if not then it sets the track to 1
        if (!Shuffle)
        {
            TrackNumber = 0;
            PlaySong();
        }

        else if (Shuffle)
        {
            TrackNumber = Random.Range(0, Tracks.Length);
            PlaySong();
        }

        // Add listeners to handle the slider events
        audioSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void Update()
    { /*
        //Checks if paused
        if (!Paused)
        {
            //Keeps track of time so we know how far we are into the song
            OnUpdate?.Invoke(Time.deltaTime);
            CurrentTime = CurrentTime + Time.deltaTime;
            progress = CurrentTime / TrackLength * 100;

            //Calculates the time we have remaining
            remaining = TrackLength - CurrentTime;
            remainingminutes = ((int)remaining) / 60;
            remainingseconds = remaining - (remainingminutes * 60);

            //Displays the current progress
            DisplayProgress.value = progress;

            if (!isDragging)
            {
                audioSlider.value = CurrentTime;
            }

            //Calculates minutes and seconds for time taken
            if (displayseconds <= 59.5)
            {
                displayseconds = displayseconds + Time.deltaTime;
            }
            else if (displayseconds >= 59.5)
            {
                displayseconds = 0;
                displayminutes += 1;
            }

            //Displays the time in minutes and seconds
            if (displayseconds < 9.5)
            {
                DisplayTime.text = displayminutes.ToString("F0") + " : 0" + displayseconds.ToString("F0");
            }
            else if (displayseconds > 9.5)
            {
                DisplayTime.text = displayminutes.ToString("F0") + " : " + displayseconds.ToString("F0");
            }

            //Displays the time remaining in minutes and seconds
            if (remainingseconds < 9.5)
            {
                DisplayRemaining.text = "-" + remainingminutes.ToString("F0") + " : 0" + remainingseconds.ToString("F0");
            }
            else if (remainingseconds > 9.5)
            {
                DisplayRemaining.text = "-" + remainingminutes.ToString("F0") + " : " + remainingseconds.ToString("F0");
            }
        }*/
        AudioSource audio = GetComponent<AudioSource>();
        TrackLength = audio.clip.length;

        if (!Paused)
        {
            OnUpdate?.Invoke(Time.deltaTime);
            CurrentTime += Time.deltaTime;

            float progress = CurrentTime / TrackLength;
            DisplayProgress.value = progress;

            if (!isDragging)
            {
                audioSlider.value = CurrentTime;
            }
        }
        DisplayRemaining.text = "-" + FormatTime(TrackLength - CurrentTime);
        DisplayTime.text = FormatTime(CurrentTime);
    }

    IEnumerator Playing()
    {
        //Get's a reference for the AudioSource and displays in the console what song is playing, how long it is and where we are starting from
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
         
        Debug.Log("Playing Track " + TrackNumber + " Song Length " + audio.clip.length.ToString("F2") + " Playing from " + CurrentTime.ToString("F2"));

       /* //Displays the song name
        DisplayName.text = audio.clip.name;

        // Set the slider's max value to the length of the audio clip
        audioSlider.maxValue = audio.clip.length;

        // Add listeners to handle the slider events
        audioSlider.onValueChanged.AddListener(OnSliderValueChanged);

        //Figures out how long is left of the audio clip and then waits until it's finished before continuing
        ClipTime = audio.clip.length - CurrentTime; */

        yield return new WaitForSeconds(audio.clip.length - CurrentTime);

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
                    // TrackNumber += 1;
                     TrackNumber = (TrackNumber + 1) % Tracks.Length;
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
    }

    public void PlaySong()
    {
        //Get's a reference for the AudioSource
        AudioSource audio = GetComponent<AudioSource>();

        if (TrackNumber < 0 || TrackNumber >= Tracks.Length) return;

        audio.clip = Tracks[TrackNumber];
        CurrentTime = 0;

        //Sets the audio slider back to 0
        audioSlider.value = 0;

        //resets the displayed time
        displayseconds = 0;
        displayminutes = 0;

        //Displays the song name
        DisplayName.text = audio.clip.name;

        // Set the slider's max value to the length of the audio clip
        audioSlider.maxValue = audio.clip.length;

        // Add listeners to handle the slider events
        audioSlider.onValueChanged.AddListener(OnSliderValueChanged);

        //Figures out how long is left of the audio clip and then waits until it's finished before continuing
        ClipTime = audio.clip.length - CurrentTime;

        if (!Paused)
        {
            StartCoroutine(Playing());
        }
    }

    public void Skip()
    {
        StopCoroutine(Playing());

        //Plays the next song
        //If shuffled, it calls the shuffle function, if not shuffled it increases the track number and then plays the next song
        if (!Shuffle)
        {
            /* PrevTrack = TrackNumber;
             TrackNumber += 1; */
            TrackNumber = (TrackNumber + 1) % Tracks.Length;
            PlaySong();
        }

        else if (Shuffle)
        {
            Shuffled();
        }
    }

    public void Back()
    {
        //Plays the previous song
        //If shuffled it plays the previous track number, if not shuffled it simply goes back 1 track
        /* if (!Shuffle)
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
         }*/

        StopCoroutine(Playing());
        if (Shuffle)
        {
            TrackNumber = PrevTrack;
        }
        else
        {
            TrackNumber = (TrackNumber - 1 + Tracks.Length) % Tracks.Length;
        }
        PlaySong();
    }

    public void OnPointerDown()
    {
        isDragging = true;
        Pause();
        dragged = false;
    }

    public void OnPointerUp()
    {
        isDragging = false;
        Resume();
        dragged = true;
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

        PauseButton.SetActive(false);
        ResumeButton.SetActive(true);
    }

    public void Resume()
    {
        //Gets a reference to the audio source
        AudioSource audio = GetComponent<AudioSource>();

        //Starts the coroutine again and unpauses the audio
        StartCoroutine(Playing());
        Paused = false;
        audio.UnPause();

        PauseButton.SetActive(true);
        ResumeButton.SetActive(false);
    }

    private void Shuffled()
    {
        //Saves the current track as the previous track before randomising the current track
        /*   PrevTrack = TrackNumber;
           TrackNumber = Random.Range(1, 27);

           //Checks to make sure you can't hear the same song twice in a row
           if (TrackNumber == PrevTrack)
           {
               Shuffled();
           }

           else if (TrackNumber != PrevTrack)
           {
               PlaySong();
           } */

        PrevTrack = TrackNumber;
        do
        {
            TrackNumber = Random.Range(0, Tracks.Length);
        } while (TrackNumber == PrevTrack);

        PlaySong();
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

    public void OnSliderValueChanged(float value)
    {
        //Get's a reference for the AudioSource
        AudioSource audio = GetComponent<AudioSource>();

        if (isDragging)
        {
            // Update the audio playback time to match the slider value
            audio.time = value;
            CurrentTime = value;

            displayseconds = CurrentTime;

            displayminutes = ((int)displayseconds) / 60;
            displayseconds = displayseconds - (displayminutes * 60);

            dragged = true;
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return $"{minutes:00}:{seconds:00}";
    }
}
