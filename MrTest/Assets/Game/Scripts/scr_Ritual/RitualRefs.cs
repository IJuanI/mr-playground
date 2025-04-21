using System.Collections;
using UnityEngine;

public class RitualRefs : MonoBehaviour
{
    public static RitualRefs allRefs;
    [SerializeField]float waitSecondsForCreators;
    [SerializeField][TagSelector]string tagBell; 
    [HideInInspector]
    public Bell bellRef;

    private void Awake() {
        if(allRefs == null)
        {
            allRefs = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        StartCoroutine(WaitForCreators());
    }

    IEnumerator WaitForCreators()
    {
        yield return new WaitForSeconds(waitSecondsForCreators);
        bellRef = GameObject.FindWithTag(tagBell).GetComponent<Bell>();

    }
}
