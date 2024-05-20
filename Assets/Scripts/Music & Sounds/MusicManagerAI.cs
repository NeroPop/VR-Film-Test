using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]

public class MusicManagerAI : MonoBehaviour
{
    [Header("Soundtrack Audio")]
    [SerializeField]
    private AudioClip[] tracks;

    [Header("Display Elements")]
    public TMP_Text DisplayName;
    public TMP_Text DisplayTime;
    public TMP_Text DisplayRemaining;
    public Slider DisplayProgress;
    public Slider AudioSlider;
    public GameObject PauseButton;
    public GameObject ResumeButton;

    [Header("Music Information")]
    [ReadOnly]
    [SerializeField]
    private int TrackNumber = 1;

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

    private AudioSource audioSource;
    private int PrevTrack;
    private bool isDragging = false;

    public event Action<float> OnUpdate;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (Shuffle)
        {
            TrackNumber = Random.Range(0, tracks.Length);
        }
        PlaySong();

        AudioSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void Update()
    {
        if (!Paused)
        {
            OnUpdate?.Invoke(Time.deltaTime);
            CurrentTime += Time.deltaTime;
            TrackLength = audioSource.clip.length;

            float progress = CurrentTime / TrackLength;
            DisplayProgress.value = progress;

            if (!isDragging)
            {
                AudioSlider.value = CurrentTime;
            }

            DisplayTime.text = FormatTime(CurrentTime);
            DisplayRemaining.text = "-" + FormatTime(TrackLength - CurrentTime);
        }
    }

    private IEnumerator Playing()
    {
        audioSource.Play();
        DisplayName.text = audioSource.clip.name;
        AudioSlider.maxValue = audioSource.clip.length;

        Debug.Log($"Playing Track {TrackNumber + 1}, Song Length: {audioSource.clip.length:F2}, Playing from: {CurrentTime:F2}");

        yield return new WaitForSeconds(audioSource.clip.length - CurrentTime);

        if (!Paused)
        {
            if (Shuffle)
            {
                Shuffled();
            }
            else
            {
                TrackNumber = (TrackNumber + 1) % tracks.Length;
                PlaySong();
            }
        }
    }

    public void PlaySong()
    {
        if (TrackNumber < 0 || TrackNumber >= tracks.Length) return;

        audioSource.clip = tracks[TrackNumber];
        CurrentTime = 0;

        StartCoroutine(Playing());
    }

    public void Skip()
    {
        StopCoroutine(Playing());
        if (Shuffle)
        {
            Shuffled();
        }
        else
        {
            TrackNumber = (TrackNumber + 1) % tracks.Length;
            PlaySong();
        }
    }

    public void Back()
    {
        StopCoroutine(Playing());
        if (Shuffle)
        {
            TrackNumber = PrevTrack;
        }
        else
        {
            TrackNumber = (TrackNumber - 1 + tracks.Length) % tracks.Length;
        }
        PlaySong();
    }

    public void OnPointerDown()
    {
        isDragging = true;
        Pause();
    }

    public void OnPointerUp()
    {
        isDragging = false;
        Resume();
    }

    public void Pause()
    {
        Paused = true;
        audioSource.Pause();
        Debug.Log($"Paused at {CurrentTime:F2}");

        PauseButton.SetActive(false);
        ResumeButton.SetActive(true);
    }

    public void Resume()
    {
        Paused = false;
        audioSource.UnPause();

        PauseButton.SetActive(true);
        ResumeButton.SetActive(false);

        StartCoroutine(Playing());
    }

    private void Shuffled()
    {
        PrevTrack = TrackNumber;
        do
        {
            TrackNumber = Random.Range(0, tracks.Length);
        } while (TrackNumber == PrevTrack);

        PlaySong();
    }

    public void ToggleShuffle()
    {
        Shuffle = !Shuffle;
    }

    public void OnSliderValueChanged(float value)
    {
        if (isDragging)
        {
            audioSource.time = value;
            CurrentTime = value;
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return $"{minutes:00}:{seconds:00}";
    }
}
