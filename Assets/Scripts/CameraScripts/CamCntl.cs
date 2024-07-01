using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor.Experimental.GraphView;

public class CamCntl : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private CinemachinePOV povComponent;
    private bool isRightMouseButtonHeld;

    void Start()
    {
        if (virtualCamera != null)
        {
            povComponent = virtualCamera.GetCinemachineComponent<CinemachinePOV>();
        }
    }

    void Update()
    {
        //ÉLÅ[ì¸óÕÇÃîªíË
        if (Input.GetMouseButtonDown(1))
        {
            isRightMouseButtonHeld = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRightMouseButtonHeld= false;
            Cursor.lockState = CursorLockMode.None;
            ResetPOVInput();
        }

        //éãì_ëÄçÏÇÃèàóù
        if(povComponent != null)
        {
            if (isRightMouseButtonHeld)
            {
                povComponent.m_HorizontalAxis.m_InputAxisName = "Mouse X";
                povComponent.m_VerticalAxis.m_InputAxisName = "Mouse Y";
            }
            else
            {
                povComponent.m_HorizontalAxis.m_InputAxisName = "";
                povComponent.m_VerticalAxis.m_InputAxisName = "";
            }
        }
    }

    private void ResetPOVInput()
    {
        if(povComponent != null)
        {
            povComponent.m_HorizontalAxis.m_InputAxisValue = 0f;
            povComponent.m_VerticalAxis.m_InputAxisValue = 0f;
        }
    }
}
