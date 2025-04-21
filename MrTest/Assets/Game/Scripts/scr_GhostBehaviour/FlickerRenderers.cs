using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FlickerRenderers : MonoBehaviour
{
    public float  minFlickerTime =  0;
    public float maxFlickerTime = 0;
    List<SkinnedMeshRenderer> renderers;
    bool isFlickering = false;
    bool currentRendererState = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderers = new List<SkinnedMeshRenderer>(GetComponentsInChildren<SkinnedMeshRenderer>());
    }

    void ChangeRender(bool state)
    {
        renderers.ForEach(r => r.enabled = state);
    }

    public void StartFlickeringRenderer(float timerFlickering)
    {
        if(!isFlickering)
        {
            StartCoroutine(FlickeringRenderer(timerFlickering));
        }
    }

    IEnumerator FlickeringRenderer(float timerFlickering)
    {
        float elapsedTime = 0;
        float rdmTimer = 0;
        while(timerFlickering > elapsedTime)
        {
            rdmTimer = Random.Range(minFlickerTime,maxFlickerTime);
            yield return new WaitForSeconds(rdmTimer);
            currentRendererState = !currentRendererState;
            ChangeRender(currentRendererState);
            elapsedTime+= rdmTimer;
        }
    }
    
}
