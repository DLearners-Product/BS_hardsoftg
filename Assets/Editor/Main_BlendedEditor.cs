﻿using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Main_Blended)), CanEditMultipleObjects]
public class Main_BlendedEditor : Editor {
    // private ReorderableList list;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
    }
}