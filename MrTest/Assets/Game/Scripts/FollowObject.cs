using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField]Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = target.localPosition;
    }
}
