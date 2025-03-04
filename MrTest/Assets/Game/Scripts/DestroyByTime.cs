using UnityEngine;

public class DestroyByTime : MonoBehaviour
{   
    [SerializeField]GameObject root;
    [SerializeField]float time;
    [SerializeField]bool destroy_in_time = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(destroy_in_time)
        Destroy(root? root:gameObject,time);
    }

    public void DestroyWDelay()
    {
        Destroy(root? root:gameObject,time);
    }

    public void DestroyNow()
    {
        Destroy(root? root:gameObject);
    }
}
