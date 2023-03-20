using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MainBlendedData)), CanEditMultipleObjects]
public class Main_BlendedEditor : Editor {

    public static void RepaintInspector(System.Type t) {
        Editor[] ed = (Editor[])Resources.FindObjectsOfTypeAll<Editor>();
        Debug.Log("Length : "+ed.Length);
        for (int i = 0; i < ed.Length; i++)
        {
            if (ed[i].GetType() == t)
            {
                Debug.Log("Repaint applied");
                ed[i].Repaint();
                return;
            }
        }
    }


    public override void OnInspectorGUI() {
        EditorGUI.BeginChangeCheck();

        base.OnInspectorGUI();
        if(GUILayout.Button("Click")){
            RepaintInspector(typeof(Main_BlendedEditor));
            // MainBlendedData.instance.UpdateInspector();
        }

        // if(EditorGUI.EndChangeCheck()){
        //     RepaintInspector(typeof(Main_BlendedEditor));
        //     // Debug.Log("Editor Changes are done...");
        // }
    }
}