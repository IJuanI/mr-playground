using UnityEngine;

public class DesatachParent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]bool by_event = false;
    void Start()
    {
        if (!by_event)
        transform.SetParent(null);
    }

    public void Desatach()
    {
        transform.SetParent(null);
    }

}
