using UnityEngine;

public class GlowLightText : MonoBehaviour
{
    [SerializeField]GameObject text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InteractiveSwitch interruptor = InteractiveSwitch.InstanceLight;
        interruptor.OnSwitch.AddListener(DisableText);
        interruptor.OffSwitch.AddListener(EnableText);
    }

    void EnableText()
    {
        text.SetActive(true);
    }

    void DisableText()
    {
        text.SetActive(false);
    }
}
