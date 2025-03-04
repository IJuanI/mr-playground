using UnityEngine;

public class AttachOnCollision : MonoBehaviour
{
    [SerializeField]Rigidbody rb;
    [TagSelector][SerializeField]string tag_col;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.CompareTag(tag_col))
        {
            transform.SetParent(other.transform);
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }
    
    void OnTriggerExit(Collider other) 
    {
        if(other.transform.CompareTag(tag_col))
        {
            transform.SetParent(null);
            rb.isKinematic = false;
        }
    }
}
