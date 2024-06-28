using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;


public class SceneEnumGenerator : MonoBehaviour
{
    [MenuItem("Tools/Generate Scene Enum")]
    public static void GenerateSceneEnum()
    {
        string enumName = "SceneNames";
        string filePathAndName = "Assets/Scripts/SceneScripts/" + enumName + ".cs";

        string[] scenes = EditorBuildSettings.scenes
            .Select(scene => Path.GetFileNameWithoutExtension(scene.path))
            .ToArray();

        using (StreamWriter sw = new StreamWriter(filePathAndName))
        {
            sw.WriteLine("public enum " + enumName);
            sw.WriteLine("{");
            foreach (string scene in scenes)
            {
                sw.WriteLine("\t" + scene + ",");
            }

            sw.WriteLine("}");
        }

        AssetDatabase.Refresh();
    }
}
