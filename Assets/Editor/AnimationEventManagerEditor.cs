using UnityEngine;
using UnityEditor;
using System.Reflection;
/*
[CustomEditor(typeof(AnimationEventManager))]
public class AnimationEventManagerEditor : Editor
{
    private SerializedProperty animationEventsProp;
    private SerializedProperty isPausedProp;
    private SerializedProperty DebugTimeProp;


    private float currentTime;

    private void OnEnable()
    {
        AnimationEventManager eventManager = (AnimationEventManager)target;
        animationEventsProp = serializedObject.FindProperty("animationEvents");
        isPausedProp = serializedObject.FindProperty("isPaused");
        DebugTimeProp = serializedObject.FindProperty("DebugTime");

        // Subscribe to the event manager's update event to update the current time
        eventManager.OnUpdate += UpdateCurrentTime;
    }


    private void OnDisable()
    {
        // Unsubscribe from the event manager's update event
        AnimationEventManager eventManager = (AnimationEventManager)target;
        eventManager.OnUpdate -= UpdateCurrentTime;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // Display the current time (read-only)
        EditorGUILayout.LabelField("Current Time", currentTime.ToString("F2"));

        // Display the isPaused variable
        EditorGUILayout.PropertyField(isPausedProp);

        // Display the DebugTime variable
        EditorGUILayout.PropertyField(DebugTimeProp);

        // Ensure animationEventsProp is not null before using it
        if (animationEventsProp != null)
        {
            // Display the animationEvents property
            EditorGUILayout.PropertyField(animationEventsProp, new GUIContent("Animation Events"), true);

        }

        serializedObject.ApplyModifiedProperties();
    }


    private void OnSceneGUI()
    {
        // Display the time when events get triggered in the Scene view
        Handles.Label(Vector3.zero, "Triggered Time: " + currentTime.ToString("F2"));
    }

    private void UpdateCurrentTime(float time)
    {
        // Update the current time
        currentTime = time;
    }
}
*/