using UnityEngine;
using System.Collections;

public class BellStep : RitualStep
{
    public int chimmes;
    Bell bell;
    
    private void Start() {
        bell = RitualRefs.allRefs.bellRef;
    }

    protected override void CheckCompleteStep()
    {
        if(!activeStep)return;
        bell.chimesCount = 0;
        START_STEP?.Invoke();
        StartCoroutine(WaitForComplete());
    }

    IEnumerator WaitForComplete()
    {
        yield return new WaitUntil(() => bell.chimesCount == chimmes);
        FINISH_STEP?.Invoke();
    }


}
