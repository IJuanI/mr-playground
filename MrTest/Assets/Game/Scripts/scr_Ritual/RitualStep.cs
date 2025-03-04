using UnityEngine;
using UnityEngine.Events;
public abstract class RitualStep : MonoBehaviour
{
    [HideInInspector]
    public bool activeStep;
    public UnityEvent START_STEP;
    public UnityEvent FINISH_STEP;

    protected abstract void CheckCompleteStep();
    public virtual void InitStep()
    {
        activeStep = true;
        CheckCompleteStep();
    }

    public virtual void StopStep()
    {
        activeStep = false;
    }
}
