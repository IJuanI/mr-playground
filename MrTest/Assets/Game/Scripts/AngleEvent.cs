using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class AngleEvent : MonoBehaviour
{
    public float angle_trigger;
    public UnityEvent ANGLE_EVENT_ENTER;
    public UnityEvent ANGLE_EVENT_LEAVE;
    bool enter = true;
    bool leave = false;
    public bool once;
    Vector3 init_angle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        init_angle = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if(!enter && Math.Abs( Mathf.DeltaAngle(init_angle.z,transform.eulerAngles.z)) > angle_trigger)
        {
            enter = true;
            leave = false;
            ANGLE_EVENT_ENTER?.Invoke();
        }
        else
        if(!leave && Math.Abs( Mathf.DeltaAngle(init_angle.z,transform.eulerAngles.z)) < angle_trigger)
        {
            enter = false;
            leave = true;
            ANGLE_EVENT_LEAVE?.Invoke();
        }
    }
}
