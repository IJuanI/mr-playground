using Unity.Mathematics;
using UnityEngine;

public class SmoothDirection : MonoBehaviour
{
    public float speedLook = 0.5f;
    public Transform targetToLook;
    public Transform targetToSmooth;

    private float targetYRotation;

    void Start()
    {
        targetYRotation = targetToSmooth.eulerAngles.y;
    }

    void Update()
    {
        // Mirar hacia el objetivo y obtener solo el ángulo Y
        transform.LookAt(targetToLook);
        targetYRotation = transform.eulerAngles.y;

        // Obtener la rotación actual de targetToSmooth
        Vector3 smoothRotation = targetToSmooth.eulerAngles;

        // Interpolar solo el ángulo Y
        smoothRotation.y = Mathf.LerpAngle(smoothRotation.y, targetYRotation, Time.deltaTime * speedLook);

        // Aplicar la nueva rotación
        targetToSmooth.rotation = Quaternion.Euler(smoothRotation);
    }
}
