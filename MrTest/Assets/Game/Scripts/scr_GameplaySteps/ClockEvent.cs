using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClockEvent : GameplayStep
{   
    [SerializeField]float hour;
    [SerializeField]float minutes;
    public NeedleTrigger hour_event;
    public NeedleTrigger minute_event;
    public bool min_active = false;
    public bool hour_active = false;
    Coroutine EventCoroutine;
    
    private void Start() {
        hour_event.time = hour;
        minute_event.time = minutes;

        hour_event.ACTIVE_NEEDLE_EVENT.AddListener(EnterTriggerEvent);
        minute_event.ACTIVE_NEEDLE_EVENT.AddListener(EnterTriggerEvent);
        hour_event.DESACTIVE_NEEDLE_EVENT.AddListener(ExitTriggerEvent);
        minute_event.DESACTIVE_NEEDLE_EVENT.AddListener(ExitTriggerEvent);
    }

    void EnterTriggerEvent(bool is_minute)
    {
        if(is_minute)
        {
            min_active = true;
        }
        else
        {
            hour_active = true;
        }


        if(hour_active && min_active)
        {
            EventCoroutine = StartCoroutine(StartEvent());
        }
    }


    void ExitTriggerEvent(bool is_minute)
    {
        if(is_minute)
        {
            min_active = false;
        }
        else
        {
            hour_active = false;
        }
        
        if(EventCoroutine != null)
        {
            StopCoroutine(EventCoroutine);
        }
    }

    IEnumerator StartEvent()
    {
        yield return new WaitForSeconds(3);
        START_EVENT?.Invoke();
    }

    //called from animation.
    public void EndClockEvent()
    {
        END_EVENT?.Invoke();
    }
}
