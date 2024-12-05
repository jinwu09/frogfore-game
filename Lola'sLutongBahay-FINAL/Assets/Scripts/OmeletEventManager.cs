using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OmeletEventManager : MonoBehaviour
{
    public UnityEvent onCutEvent;
    public UnityEvent onCookEvent;
    public UnityEvent onServeEvent;

    public static OmeletEventManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void InvokeCutEvent()
    {
        onCutEvent.Invoke();
    }

    public void InvokeCookEvent()
    {
        onCookEvent.Invoke();
    }

    public void InvokeServeEvent()
    {
        onServeEvent.Invoke();
    }
}

