using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MainBlendedData)), CanEditMultipleObjects]
public class Main_BlendedEditor : Editor {
    // private ReorderableList list;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if(GUILayout.Button("Click")){
            MainBlendedData.instance.UpdateInspector();
        }
    }
}