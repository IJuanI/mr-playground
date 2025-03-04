using UnityEngine;
using UnityEngine.Events;


public abstract class MethodsForEvents: MonoBehaviour
{
    public virtual void MethodForStart(){}
    public virtual void MethodForEnd(){}

    public UnityEvent START_METHOD_EVENT;
    public UnityEvent END_METHOD_EVENT;

    public virtual void OnDisable() {
        END_METHOD_EVENT?.Invoke();
    }
}
