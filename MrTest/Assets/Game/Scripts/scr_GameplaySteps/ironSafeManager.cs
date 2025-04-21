using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ironSafeManager : MonoBehaviour
{
    [SerializeField]float timingCheck;
    [SerializeField]List<int> safeCode = new();
    [SerializeField]NeedleTrigger needle;
    [SerializeField]UnityEvent UNLOCK_INDEX_LOCK;
    [SerializeField]UnityEvent UNLOCK_TOTAL_CODE;
    Coroutine EventCoroutine;
    int indexCode = 0;
    private void Start() {
        needle.time = safeCode[indexCode];
        needle.ACTIVE_NEEDLE_EVENT.AddListener(EnterTriggerEvent);
        needle.DESACTIVE_NEEDLE_EVENT.AddListener(ExitTriggerEvent);
    }

    void EnterTriggerEvent(bool _)
    {
        EventCoroutine = StartCoroutine(StartEvent());
    }


    void ExitTriggerEvent(bool _)
    {
        
        if(EventCoroutine != null)
        {
            StopCoroutine(EventCoroutine);
        }
    }

    IEnumerator StartEvent()
    {
        yield return new WaitForSeconds(timingCheck);
        UNLOCK_INDEX_LOCK?.Invoke();
        if(indexCode == safeCode.Count-1)
        {
            UNLOCK_TOTAL_CODE?.Invoke();
        }
        else
        {
            indexCode++;
            needle.UpdateIndex(safeCode[indexCode]);
        }
    }

}
