using UnityEngine;

public class LookForPlayer : BaseBehaviour
{
    public TriggerEvent coneVision;
    void Start()
    {
        coneVision.TRIGGER_ENTER.AddListener(Found);
    }
    public override void InitBehaviour()
    {
        base.InitBehaviour();
        coneVision.gameObject.SetActive(true);
    }
    void Found()
    {
        FINISH_BY_BEHAIVIOUR?.Invoke();
    }

}
