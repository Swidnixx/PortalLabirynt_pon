using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Generator))]
public class EditorForGenerator : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if( GUILayout.Button("Generuj") )
        {
            //naciœniêto przycisk
            Generator g = target as Generator;
            g.Generate();
        }
    }
}
