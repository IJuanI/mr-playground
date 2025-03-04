using UnityEngine;

public class CreateLiquid : MonoBehaviour
{
    void Update()
    {

        float dot = Vector3.Dot(transform.up, Vector3.up);

        if (dot < 0)
        {
            //start liquid
        }
        else
        {
            //end loquid
        }
            
    }

    float NormalizeAngle(float angle) 
    {
        return (angle > 180) ? angle - 360 : angle;
    }
}
