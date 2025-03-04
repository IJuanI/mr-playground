
using UnityEngine;
using UnityEngine.Events;

public class InteractiveSwitch : MonoBehaviour
{   
    public static InteractiveSwitch InstanceLight;
    
    public UnityEvent OnSwitch;
    public UnityEvent OffSwitch;
    [HideInInspector]
    public bool current_state = true;

    private void Awake() {
        InstanceLight = this;
    }

    public  void ChangeState()
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
