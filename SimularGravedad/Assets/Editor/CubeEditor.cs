using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(cube))]
public class CubeEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        cube cube = (cube)target;

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Generate Color"))
        {
            cube.GenerateColor();
        }

        if (GUILayout.Button("Reset"))
        {
            cube.Reset();
        }

        GUILayout.EndHorizontal();
    }

}
