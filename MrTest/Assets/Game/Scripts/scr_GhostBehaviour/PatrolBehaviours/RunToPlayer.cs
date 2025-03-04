using UnityEngine;

public class RunToPlayer : BaseBehaviour
{
    [SerializeField]Transform rootTransform;
    [SerializeField]Transform followRotObject; //need to be positioned in the finish target position.
    [SerializeField]float tresholdDistance;
    [SerializeField]Color colorGizmoTreshold;
    [SerializeField]float speed;
    Transform playerTransform;
    bool isRunning = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        followRotObject.position = playerTransform.position;
    }

    public override void InitBehaviour()
    {
        base.InitBehaviour();
        isRunning = true;
    }
    void Update()
    {
        if(isRunning)
        {
            rootTransform.Translate(Vector3.forward * speed);
            SearchAnotherPoint();
        }
        
    }

    void SearchAnotherPoint()
    {
        if(Vector3.Distance(followRotObject.position,rootTransform.position) < tresholdDistance)
        {
            FINISH_BY_BEHAIVIOUR?.Invoke();
            isRunning = false;
        }
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = colorGizmoTreshold;
        Gizmos.DrawWireSphere(rootTransform.position,tresholdDistance);
    }
}
