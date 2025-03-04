using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    [HideInInspector]
    public static bool isActiveGhost = false;
    public float minAppearDelay;
    float minInitAppearDelay;
    public float totalGameTime = 0;
    public List<MethodsForEvents> creepyEvents = new();


    private void Start() {
        isActiveGhost = false;
        minInitAppearDelay = minAppearDelay;
        StartCoroutine(GhostAppear());
    }

    IEnumerator GhostAppear()
    {
        while(Time.time <= totalGameTime)
        {
            yield return new WaitForSeconds(minAppearDelay);
            if(isActiveGhost) continue;

            if(Random.Range(0,100)<= CalculateAppearChance() )
            {
                isActiveGhost = true;
                int randomEventIndex = Random.Range(0,creepyEvents.Count);
                creepyEvents[randomEventIndex].MethodForStart();
                creepyEvents[randomEventIndex].END_METHOD_EVENT.RemoveListener(EndCreeypyEvent);
                creepyEvents[randomEventIndex].END_METHOD_EVENT.AddListener(EndCreeypyEvent);
            }
            else
            {
                 minAppearDelay = Mathf.Max(minAppearDelay / 2, 1f);
            }
        }
    }

    void EndCreeypyEvent()
    {
        isActiveGhost = false;
        minAppearDelay = minInitAppearDelay;
    }

    float CalculateAppearChance()
    {
        float remainingTime = totalGameTime - Time.time;
        return Mathf.Clamp(100f * (1f - (remainingTime / totalGameTime)), 1f, 100f);
    }
}
