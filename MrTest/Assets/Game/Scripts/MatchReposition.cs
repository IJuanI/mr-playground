using Oculus.Interaction;
using UnityEngine;

public class MatchReposition : MonoBehaviour
{
    [SerializeField]GameObject match_prefab;
    [SerializeField]Transform pos_transform;
    [SerializeField] GameObject current_match; 
    PointableUnityEventWrapper current_pointable;

    private void Start() {
        
        if(current_match != null)
        {
            current_pointable = current_match.GetComponent<PointableUnityEventWrapper>();
            current_pointable.WhenSelect.AddListener(CreateNewMatch);
        }
    }

    void CreateNewMatch(PointerEvent e)
    {
        if( e.Type == PointerEventType.Select)
        {
            current_pointable.WhenSelect.RemoveListener(CreateNewMatch);
            current_match = Instantiate(match_prefab,pos_transform.position,pos_transform.rotation);
            current_match.transform.SetParent(pos_transform);
            current_pointable = current_match.GetComponent<PointableUnityEventWrapper>();
            current_pointable.WhenSelect.AddListener(CreateNewMatch);
        }
    
    }
}
