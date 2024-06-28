using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void LoadScene(SceneNames scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
