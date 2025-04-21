using UnityEngine;

public class Bell : MonoBehaviour
{
    public int chimesCount;
    [TagSelector][SerializeField]string tagTrigger;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == tagTrigger)
        {
            chimesCount++;
        }
    }
}
