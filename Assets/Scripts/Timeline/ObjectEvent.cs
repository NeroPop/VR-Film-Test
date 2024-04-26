using UnityEngine;

public class ObjectEvent : MonoBehaviour
{
    public void StartAnimation(AnimationEvent animEvent)
    {
        // Your animation code here
        Debug.Log("Animation started at time: " + animEvent.timeInSeconds);
    }
}
