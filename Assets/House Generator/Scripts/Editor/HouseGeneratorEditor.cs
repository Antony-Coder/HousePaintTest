using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HouseGenerator))]
public class HouseGeneratorEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        HouseGenerator myScript = (HouseGenerator)target;

        GUI.color = Color.cyan;
        if (GUILayout.Button("Generate House",GUILayout.MinHeight(30)))
        {
            myScript.Generate();
        }
    }
}
