using UnityEngine;

public class VisionTrigger : MonoBehaviour
{
    [TagSelector][SerializeField]string tagPlayer;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == tagPlayer)
        {

        }
    }

    void OnTriggerExit(Collider other)
    {
        
    }
}
