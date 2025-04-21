using UnityEngine;

public class RestoreMainObject : MonoBehaviour
{
    [SerializeField]float restoreYPosition;
    Vector3 initialPos;
    Vector3 initialRot;

    bool kinematicState;
    bool gravityState;

    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPos = transform.position;
        initialRot = transform.eulerAngles;
        kinematicState = rb.isKinematic;
        gravityState = rb.useGravity;
    }

    void RestoreObject()
    {
        rb.isKinematic = kinematicState;
        rb.useGravity = gravityState;
        transform.position = initialPos;
        transform.eulerAngles = initialRot;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= restoreYPosition)
        {
            RestoreObject();
        }
    }
}
