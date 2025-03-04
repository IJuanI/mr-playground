using UnityEngine;
using UnityEngine.Events;

public class MoveHauntedObject : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]float force;
    [SerializeField]UnityEvent START_DRAG;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RandomMove();
    }

    void RandomMove()
    {
        START_DRAG?.Invoke();
        rb.linearVelocity = transform.forward*force;
    }
}
