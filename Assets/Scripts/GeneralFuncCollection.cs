using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralFuncCollection : MonoBehaviour
{
    //ƒQ[ƒ€I—¹ˆ—
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
