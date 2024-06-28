using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        if(Enum.IsDefined(typeof(SceneNames), scene))
            SceneManager.LoadScene(scene);
    }
}
