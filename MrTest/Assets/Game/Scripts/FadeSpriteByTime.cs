using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class FadeSpriteByTime : MonoBehaviour
{
    [SerializeField]float timing_full_color;
    [SerializeField]SpriteRenderer sprite;

    [SerializeField]UnityEvent INIT_EVENT;
    [SerializeField]UnityEvent FINISH_EVENT;
    float elapsed_time;
    Color current_color = new Color(1,1,1,0);
    bool dispatch_event = false;
    
    private void Start() {
        INIT_EVENT?.Invoke();
    }


    // Update is called once per frame
    void Update()
    {
        if(current_color.a < .9f )
        {
            elapsed_time += Time.deltaTime;
            current_color.a = math.lerp(0,1,elapsed_time/timing_full_color);
            sprite.color = current_color;
        }
        else if(!dispatch_event)
        {
            dispatch_event = true;
            FINISH_EVENT?.Invoke();
        }

    }
}
