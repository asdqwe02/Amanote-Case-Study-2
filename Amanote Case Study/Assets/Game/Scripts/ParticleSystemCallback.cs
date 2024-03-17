using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemCallback : MonoBehaviour
{
    public Action particleSystemStopEvent;
    private void Awake()
    {
        var main = GetComponent<ParticleSystem>().main;
        main.stopAction = ParticleSystemStopAction.Callback;
    }

    void OnParticleSystemStopped()
    {
        particleSystemStopEvent?.Invoke();
    }
}
