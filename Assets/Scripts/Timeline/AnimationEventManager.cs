using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{
    [SerializeField] private float CurrentTime;

    public bool isPaused = false;

    public bool DebugTime = false;

    // Define the OnUpdate event
    public event Action<float> OnUpdate;

    public List<GameObject> animationEvents;

    private void Start()
    {
        Debug.Log("Manager Started");
    }

    private void Update()
    {
        if (!isPaused)
        {
            // Invoke the OnUpdate event with the current time
            OnUpdate?.Invoke(Time.time);

            CurrentTime = Time.time;

            if (DebugTime)
            {
                //debug.logging current time
                Debug.Log(Time.time);
            }

            foreach (var animEventObject in animationEvents)
            {
                AnimationEventTrigger animEvent = animEventObject.GetComponent<AnimationEventTrigger>();

                if (animEvent != null && Time.time >= animEvent.GetTime())
                {
                    animEvent.TriggerEvent();
                }
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
