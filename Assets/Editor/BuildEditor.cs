using UnityEngine;
using System.Collections;

using UnityEditor;

public class BuildEditor : MonoBehaviour
{
    static string[] sceneNames;
    static string buildDir = "Build";

    // Create a menu item for our function
    [MenuItem("Build/Windows(x86)")]
    static void PerformWindowsx86Build()
    {
        // Build/Windows(x86)/FirstPersonController.exe
        string targetDir = buildDir + "/Windows(x86)/" + PlayerSettings.productName + ".exe";
        // Run generic build of windows x86
        GenericBuild(targetDir, BuildTarget.StandaloneWindows, BuildOptions.None);
    }

    static void GenericBuild(string _targetDir, BuildTarget _buildTarget, BuildOptions _buildOptions)
    {
        // Switch the active build target
        EditorUserBuildSettings.SwitchActiveBuildTarget(_buildTarget);
        // Perform the build
        string result = BuildPipeline.BuildPlayer(sceneNames, _targetDir, _buildTarget, _buildOptions);
        // Check if there were any errors
        if(result.Length > 0)
        {
            string error = "Build Player Failure: " + result;
            // Log the error in Unity
            Debug.Log(error);
            // Log the error in the Console
            System.Console.WriteLine(error);
        }
    }
}