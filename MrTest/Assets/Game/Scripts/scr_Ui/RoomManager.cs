using UnityEngine;
using Meta.XR.MRUtilityKit;
using UnityEngine.UI;
public class RoomManager : MonoBehaviour
{
    public Button _ScanButton;

    void Start()
    {
        _ScanButton.onClick.AddListener(InitializedNewScan);
    }
    public void InitializedNewScan()
    {
        MRUK.Instance.ClearScene();
        OVRScene.RequestSpaceSetup();
    }
}
