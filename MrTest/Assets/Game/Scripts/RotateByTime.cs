using UnityEngine;

public class RotateByTime : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    Vector3 angles;
    void Start()
    {
        angles = transform.eulerAngles;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        angles.y += Time.deltaTime*speed;
        transform.eulerAngles = angles;
    }
}
