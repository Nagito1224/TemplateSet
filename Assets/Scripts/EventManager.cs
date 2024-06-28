using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;


public class EventManager : MonoBehaviour
{
    [Tooltip("イベント")]
    [SerializeField] private UnityEvent[] events;

    //コルーチン(イベント起動)の開始
    public void Play()
    {
        StartCoroutine(Progress());
    }

    //イベント起動コルーチン
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
