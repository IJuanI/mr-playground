using UnityEngine;

public class DetectPlayerBehaviour : BaseBehaviour
{
    [SerializeField]TriggerEvent detectPlayerCollider;

    void Start()
    {
        detectPlayerCollider.TRIGGER_ENTER.AddListener(TouchPlayer);
    }

    public override void InitBehaviour()
    {
        base.InitBehaviour();
        detectPlayerCollider.gameObject.SetActive(true);
    }

    void TouchPlayer()
    {
        FadeManager.globalFade.FadeOut(1);
    }
}
