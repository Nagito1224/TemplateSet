using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralFuncCollection : MonoBehaviour
{
    //�Q�[���I������
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
