using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;


public class EventManager : MonoBehaviour
{
    [Tooltip("�C�x���g")]
    [SerializeField] private UnityEvent[] events;

    //�R���[�`��(�C�x���g�N��)�̊J�n
    public void Play()
    {
        StartCoroutine(Progress());
    }

    //�C�x���g�N���R���[�`��
    private IEnumerator Progress()
    {
        var eventsExcludingLast = events.Take(events.Length - 1);
        foreach (var ev in eventsExcludingLast)
        {
            ev.Invoke();
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            yield return null;
        }

        events[events.Length - 1].Invoke();
    }
}
