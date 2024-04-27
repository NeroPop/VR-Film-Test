using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Animation Event", menuName = "Animation Event")]
public class AnimationEvent : ScriptableObject
{
    public float timeInSeconds;
    public MonoBehaviour targetScript;
    public UnityEvent onTrigger;
}
