using UnityEngine;

public class ChangeTag : MonoBehaviour
{
    [TagSelector][SerializeField]string new_tag;

    public void Change()
    {
        transform.tag = new_tag;
    }
}
