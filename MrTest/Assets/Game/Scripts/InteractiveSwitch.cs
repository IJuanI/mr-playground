using UnityEngine;
using UnityEngine.Events;

public class InteractiveSwitch : MonoBehaviour
{
    public UnityEvent OnSwitch;
    public UnityEvent OffSwitch;

    bool current_state = true;

    public void ChangeState()
    {
        current_state = !current_state;
        if(current_state)
        {
            OnSwitch.Invoke();
        }
        else
        {
            OffSwitch.Invoke();
        }
    }
}
