using UnityEngine;

public class SpawnOnStart : MonoBehaviour
{
    [SerializeField]GameObject prefab_to_instance;
    [SerializeField]Transform pos_to_instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos_to_instance = pos_to_instance ? pos_to_instance : transform;
        Instantiate(prefab_to_instance,pos_to_instance.position,pos_to_instance.rotation);
    }

}
