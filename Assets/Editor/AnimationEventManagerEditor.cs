using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AnimationEventManager))]
public class AnimationEventManagerEditor : Editor
{
    private SerializedProperty animationEventsProp;

    private void OnEnable()
    {
        animationEventsProp = serializedObject.FindProperty("animationEvents");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(animationEventsProp, true);

        serializedObject.ApplyModifiedProperties();
    }
}
