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
        //アタッチしたカメラがアクティブである場合にのみ処理を可能にする
        if (cinemachineBrain.ActiveVirtualCamera as CinemachineVirtualCamera == virtualCamera)
        {
            //入力を取得する
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            //カメラが向いている方向を前とする
            transform.rotation = Quaternion.AngleAxis(virtualCamera.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.Value, Vector3.up);

            //移動する
            transform.Translate(horizontal * speed, 0, vertical * speed);
        }
    }
}
