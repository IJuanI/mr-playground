using System.Collections.Generic;
using UnityEngine;

public class WalkAround : BaseBehaviour
{
    [SerializeField]bool overrideRootMotion;
    [SerializeField]Transform rootTransform;
    [SerializeField]Transform followRotObject;
    [SerializeField]float tresholdDistance;
    [SerializeField]float speed;
    List<GameObject> destinyPoints = new();
    Transform currentDestiny;
    public override void InitBehaviour()
    {
        base.InitBehaviour();
    
        if(destinyPoints.Count != 0)return;
        destinyPoints = new List<GameObject>( GameObject.FindGameObjectsWithTag("Destiny"));
        if(destinyPoints.Count > 0)
        {
            currentDestiny = destinyPoints[Random.Range(0,destinyPoints.Count)].transform;
        }
    }

    void SearchAnotherPoint()
    {
        if(Vector3.Distance(currentDestiny.position,rootTransform.position) < tresholdDistance)
        {
            currentDestiny = destinyPoints[Random.Range(0,destinyPoints.Count)].transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(destinyPoints.Count == 0)return;
        //search point
        SearchAnotherPoint();
        //set the object smooth rotation in the place.
        followRotObject.position = currentDestiny.position;
        //Move Forward.
        if(overrideRootMotion)
            rootTransform.Translate(Vector3.forward * speed);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(rootTransform.position,tresholdDistance);
    }
}
