using System.Collections.Generic;
using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{
    [SerializeField] private float currentTime = 0;
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
            currentTime += Time.deltaTime;

            foreach (var animEventObject in animationEvents)
            {
                AnimationEventTrigger animEvent = animEventObject.GetComponent<AnimationEventTrigger>();

                if (animEvent != null && currentTime >= animEvent.timeInSeconds)
                {
                    animEvent.onTrigger.Invoke();
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

    public void RemoveEvent(GameObject eventToRemove)
    {
        animationEvents.Remove(eventToRemove);
    }
}
