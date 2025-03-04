using System.Collections;
using UnityEngine;

public class FlickerLights : MonoBehaviour
{
    InteractiveSwitch interactiveSwitch ;
    public float minFlickerTime;
    public float maxFlickerTime;
    bool isFlickering = false;

    public void FlickerLight(float flickerTotalTime)
    {
        interactiveSwitch = InteractiveSwitch.InstanceLight;
        if(!isFlickering)
        {
            isFlickering = true;
            StartCoroutine(StartFlickeringRoutine(flickerTotalTime));
        }
    }

    IEnumerator StartFlickeringRoutine(float flickerTotalTime)
    {
        float elapsedTime = 0;

        while (elapsedTime < flickerTotalTime)
        {
            interactiveSwitch.ChangeState();
            float flickerDuration = Random.Range(minFlickerTime, maxFlickerTime);    
            yield return new WaitForSeconds(flickerDuration);
            elapsedTime += flickerDuration; 
        }

        isFlickering = false;
        OffLight();
    }

    public void OffLight()
    {
        if(interactiveSwitch.current_state)
        {
            interactiveSwitch.ChangeState();
        }
    }
}
