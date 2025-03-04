using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent TRIGGER_ENTER;
    public UnityEvent TRIGGER_EXIT;
    [TagSelector][SerializeField]string trigger_tag;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag(trigger_tag))
        {
            TRIGGER_ENTER?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(trigger_tag))
        {
            TRIGGER_EXIT?.Invoke();
        }
    }
}
