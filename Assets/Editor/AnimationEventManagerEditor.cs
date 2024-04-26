using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AnimationEventManager))]
public class AnimationEventManagerEditor : Editor
{
    private SerializedProperty animationEventsProp;
    private SerializedProperty isPausedProp;

    private void OnEnable()
    {
        animationEventsProp = serializedObject.FindProperty("animationEvents");
        isPausedProp = serializedObject.FindProperty("isPaused");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // Display the isPaused variable
        EditorGUILayout.PropertyField(isPausedProp);

        // Display the animationEvents property
        EditorGUILayout.PropertyField(animationEventsProp, new GUIContent("Animation Events"), true);

        serializedObject.ApplyModifiedProperties();
    }
}
