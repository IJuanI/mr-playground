using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NeedleTrigger : MonoBehaviour
{
    [HideInInspector]
    public float time;
    [SerializeField]bool is_minute;
    [SerializeField]Transform parent_clock_cols;
    List<GameObject> list_col = new();
    int current_index = 0;

    [HideInInspector]
    public UnityEvent<bool> ACTIVE_NEEDLE_EVENT;
    [HideInInspector]
    public UnityEvent<bool> DESACTIVE_NEEDLE_EVENT;

    private void Start() {

        for(int i = 0; i < parent_clock_cols.childCount;i++)
        {
            list_col.Add(parent_clock_cols.GetChild(i).gameObject);
        }

        current_index = (int)(is_minute?(time/5):time-1);
    }

    public void UpdateIndex(int new_time)
    {
        current_index = (int)(is_minute?(new_time/5):new_time-1);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == list_col[current_index])
        {
            ACTIVE_NEEDLE_EVENT?.Invoke(is_minute);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject == list_col[current_index])
        {
            DESACTIVE_NEEDLE_EVENT?.Invoke(is_minute);
        }
    }
}
