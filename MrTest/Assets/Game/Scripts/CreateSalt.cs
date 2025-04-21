using System;
using Unity.Mathematics;
using UnityEngine;

public class CreateSalt : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    
    

    void Update()
    {
        var emission = particles.emission;
        float dot = Vector3.Dot(transform.up, Vector3.up);

        if (dot < 0)
        {
            if(!emission.enabled)
            {
                emission.enabled = true;
            }
        }
        else
        {
            if(emission.enabled)
            {
                emission.enabled = false;
            }
        }
            
    }
}
