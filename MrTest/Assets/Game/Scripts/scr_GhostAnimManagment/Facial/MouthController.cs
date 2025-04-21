using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MouthController : MonoBehaviour
{   
    
    [SerializeField]Transform targetMouthLeft;
    [SerializeField]Transform targetMouthRight;
    [SerializeField]Vector3 maxSmileLeftValue;
    [SerializeField]Vector3 maxSmileRightValue;
    [SerializeField]Vector3 minSmileLeftValue;
    [SerializeField]Vector3 minSmileRightValue;

    [SerializeField]Transform targetMouth;
    [SerializeField]float maxOpenValue;
    [SerializeField]float maxClosedValue;
    Vector3 animVector;

    [Range(0,1)]
    [SerializeField]float openFactorValue = 0;
    [Range(0,1)]
    [SerializeField]float smileFactorValue = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animVector = targetMouth.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        animVector.z = math.lerp(maxClosedValue,maxOpenValue,openFactorValue);
        targetMouth.localPosition = animVector;

        targetMouthLeft.localPosition = Vector3.Lerp(minSmileLeftValue,maxSmileLeftValue,smileFactorValue);
        targetMouthRight.localPosition = Vector3.Lerp(minSmileRightValue,maxSmileRightValue,smileFactorValue);
    }
}
