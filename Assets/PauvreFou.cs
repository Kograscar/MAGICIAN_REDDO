using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class PauvreFou
{
    private static string currentScene;
    static PauvreFou()
    {
        currentScene = EditorApplication.currentScene;
        EditorApplication.hierarchyWindowChanged += hierarchyWindowChanged;
    }
    private static void hierarchyWindowChanged()
    {
        if (currentScene != EditorApplication.currentScene)
        {
            //a scene change has happened
            Debug.Log("Last Scene: " + currentScene);
            currentScene = EditorApplication.currentScene;
        }
    }
}
