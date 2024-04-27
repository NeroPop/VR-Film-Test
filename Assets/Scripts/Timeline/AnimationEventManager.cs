using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventManager : MonoBehaviour
{
    //Shows current time
    [SerializeField] private float CurrentTime;

    //Allows you to pause/resume time
    public bool isPaused = false;

    //Shows current time in debug
    public bool DebugTime = false;

    [SerializeField] private float StartTime = 0;

    // Define the OnUpdate event
    public event Action<float> OnUpdate;

    //UnityEvent when pause is toggled
    [SerializeField] private UnityEvent TogglePause;

    //List of Events to Trigger
    public List<GameObject> animationEvents;

    //Checks if pause is Toggled
    private bool TriggeredPause = false;

    private void Start()
    {
        CurrentTime = StartTime;
        Debug.Log("Manager Started");

        if (StartTime > 0)
        {
            Debug.Log("Start Time " + StartTime + " Seconds");
        }
    }

    private void Update()
    {
        if (!isPaused)
        {
            // Invoke the OnUpdate event with the current time
            OnUpdate?.Invoke(Time.deltaTime);

            CurrentTime = CurrentTime + Time.deltaTime;

            if (DebugTime)
            {
                //debug.logging current time
                Debug.Log(CurrentTime);
            }

            // List<GameObject> eventsToRemove = new List<GameObject>(); // Collect events to remove

            foreach (var animEventObject in animationEvents)
            {
                AnimationEventTrigger animEvent = animEventObject.GetComponent<AnimationEventTrigger>();

                if (animEvent != null && CurrentTime >= animEvent.GetTime())
                {
                    animEvent.TriggerEvent();
                   // eventsToRemove.Add(animEventObject);
                }
            }

            if(TriggeredPause)
            {
                Debug.Log("Resumed");
                TriggeredPause = false;
                TogglePause.Invoke();
            }

            // Remove events after iterating
          /*  foreach (var eventToRemove in eventsToRemove)
            {
                RemoveEvent(eventToRemove);
            } */
        }

        else
        {
            if (!TriggeredPause)
            {
                Debug.Log("Paused");
                TriggeredPause = true;
                TogglePause.Invoke();
            }
           
        }

    }

    public void PauseEvents()
    {
        isPaused = true;
    }

    public void ResumeEvents()
    {
        isPaused = false;
    }

    public void AddEvent(GameObject eventObject)
    {
        animationEvents.Add(eventObject);
    }

    public void RemoveEvent(GameObject eventObject)
    {
        animationEvents.Remove(eventObject);
    }
}
