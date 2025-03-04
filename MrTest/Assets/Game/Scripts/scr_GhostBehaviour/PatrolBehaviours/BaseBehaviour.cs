using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BaseBehaviour : MonoBehaviour
{
    public float minTimeDuration;
    public float maxTimeDuration;
    Coroutine runningCoroutine;
    [HideInInspector]
    public UnityEvent FINISH_BY_TIME;
    [HideInInspector]
    public UnityEvent FINISH_BY_BEHAIVIOUR;

    public virtual void InitBehaviour()
    {
        runningCoroutine = StartCoroutine(RunningBehaviourCoroutine());
    }

    IEnumerator RunningBehaviourCoroutine()
    {
        float rdmTime = Random.Range(minTimeDuration,maxTimeDuration);
        yield return new WaitForSeconds(rdmTime);
        FINISH_BY_TIME?.Invoke();
    }

    public virtual bool FinishPhaseByBehaviour()
    {
        return false;
    }
}
