using UnityEngine;
using UnityEngine.Events;

public class AnimationEventTrigger : MonoBehaviour
{
    public float timeInSeconds;
    [SerializeField] private UnityEvent onTrigger;

    private bool triggered = false;

    public float GetTime()
    {
        return timeInSeconds;
    }

    public void TriggerEvent()
    {
        onTrigger.Invoke();

        if (!triggered)
        {
            triggered = true;
            Debug.Log("triggered event");
            gameObject.SetActive(false);
            //  Destroy(gameObject, 3);
        }

    }
}
