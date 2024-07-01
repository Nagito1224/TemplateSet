using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private CinemachineBrain cinemachineBrain;

    void Start()
    {
        cinemachineBrain = Camera.main.GetComponent<CinemachineBrain>();
    }

    void Update()
    {
        //�A�^�b�`�����J�������A�N�e�B�u�ł���ꍇ�ɂ̂ݏ������\�ɂ���
        if (cinemachineBrain.ActiveVirtualCamera as CinemachineVirtualCamera == virtualCamera)
        {
            //���͂��擾����
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            //�J�����������Ă��������O�Ƃ���
            transform.rotation = Quaternion.AngleAxis(virtualCamera.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.Value, Vector3.up);

            //�ړ�����
            transform.Translate(horizontal * speed, 0, vertical * speed);
        }
    }
}
