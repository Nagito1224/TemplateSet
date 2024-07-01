using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        StartCoroutine(ObserveCameraAction());
    }

    private IEnumerator ObserveCameraAction()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.C));
            yield return null;

            virtualCamera.Priority = (virtualCamera.Priority == 10) ? -10 : 10;
        }
    }
}
