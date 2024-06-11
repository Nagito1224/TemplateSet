using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartUpEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent startUpEvent;

    void Start()
    {
        startUpEvent.Invoke();
    }
}
