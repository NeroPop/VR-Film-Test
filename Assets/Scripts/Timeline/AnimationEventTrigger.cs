using UnityEngine;
using UnityEngine.Events;

public class AnimationEventTrigger : MonoBehaviour
{
    [SerializeField] private float timeInSeconds;
    [SerializeField] private UnityEvent onTrigger;

    public float GetTime()
    {
        return timeInSeconds;
    }

    public void TriggerEvent()
    {
        onTrigger.Invoke();
        Debug.Log("triggered event");
    }
}
