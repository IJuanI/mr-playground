using System.Collections.Generic;
using UnityEngine;

public class AttachObjectToCamera : MonoBehaviour
{
    [SerializeField]List<Transform> objects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(Transform obj in objects)
        {
            obj.SetParent(Camera.main.transform);
            obj.localPosition = Vector3.zero;
        }
        
    }
}
