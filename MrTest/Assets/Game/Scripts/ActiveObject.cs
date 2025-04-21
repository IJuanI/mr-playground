using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ActiveObject : MonoBehaviour
{
    public bool manualActivation = false;
    [SerializeField]float delayToActive;
    [SerializeField]UnityEvent ActiveEvent;
    private void Start() {
        if(!manualActivation)
        StartCoroutine(Activate());
    }

    public void  ManualActivation()
    {
        StartCoroutine(Activate());
    }

    IEnumerator Activate()
    {
        yield return new WaitForSeconds(delayToActive);
        ActiveEvent?.Invoke();
    }
}
