using Meta.XR.MRUtilityKit;
using UnityEngine;

public class ReScanDataRoom : MonoBehaviour
{
    [SerializeField]Rigidbody rb;
    [SerializeField]float value;
    private void OnCollisionEnter(Collision other) {
        if(rb.linearVelocity.magnitude > value)
        {
            Debug.Log("ENTER IN THE COLLISION"+ transform.position);
            MRUK.Instance.ClearScene();
            OVRScene.RequestSpaceSetup();
            MRUK.Instance.LoadSceneFromDevice();
        }
    }
}
