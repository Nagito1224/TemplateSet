using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    void Update()
    {
        //“ü—Í‚ğæ“¾‚·‚é
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        //ƒJƒƒ‰‚ªŒü‚¢‚Ä‚¢‚é•ûŒü‚ğ‘O‚Æ‚·‚é
        transform.rotation = Quaternion.AngleAxis(virtualCamera.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.Value, Vector3.up);

        //ˆÚ“®‚·‚é
        transform.Translate(horizontal * speed, 0, vertical * speed);
    }
}
