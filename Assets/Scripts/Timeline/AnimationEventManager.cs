using System.Collections.Generic;
using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{
    public bool isPaused = false;

    public List<GameObject> animationEvents;

    private void Start()
    {
        Debug.Log("Hello World");
    }

    private void Update()
    {
        if (!isPaused)
        {

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
