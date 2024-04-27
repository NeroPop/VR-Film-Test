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
        //Sets the time to where you want to start and tells you where it started in debug
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

            //Sets the current time when not paused.
            CurrentTime = CurrentTime + Time.deltaTime;

            if (DebugTime)
            {
                //debug.logging current time if you check the option in the inspector.
                Debug.Log(CurrentTime);
            }

            // List<GameObject> eventsToRemove = new List<GameObject>(); // Collect events to remove
            
            //Checks the animation events in the list and if the current time is the same or greater than the time set in the event then it triggers them.
            foreach (var animEventObject in animationEvents)
            {
                AnimationEventTrigger animEvent = animEventObject.GetComponent<AnimationEventTrigger>();

                if (animEvent != null && CurrentTime >= animEvent.GetTime())
                {
                    animEvent.TriggerEvent();
                   // eventsToRemove.Add(animEventObject);
                }
            }

            // If Pause has been turned off then say in console + invoke the toggle pause event + set's triggered pause to false so it only triggers once.
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

        //If paused, it will say so in the console + invoke the toggle paused event and set Triggered pause to true so it only triggers once.
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
