using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdderTimer : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] TimerManager timerManager;

    public void AddTimer()
    {
        timerManager.AddTimer(time);
    }
}
