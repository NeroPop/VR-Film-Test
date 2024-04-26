using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{
    public AnimationEvent[] animationEvents;

    private float currentTime = 0;
    private bool isPaused = false;

    private void Update()
    {
        if (!isPaused)
        {
            currentTime += Time.deltaTime;

            foreach (var animEvent in animationEvents)
            {
                if (currentTime >= animEvent.timeInSeconds)
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

    public void RemoveEvent(AnimationEvent eventToRemove)
    {
        for (int i = 0; i < animationEvents.Length; i++)
        {
            if (animationEvents[i] == eventToRemove)
            {
                animationEvents[i] = null;
                break;
            }
        }
    }
}
