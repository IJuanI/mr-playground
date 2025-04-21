using System.Collections;
using UnityEngine;

public class SpawnOnStart : MonoBehaviour
{
    [SerializeField]GameObject prefab_to_instance;
    [SerializeField]Transform pos_to_instance;
    [SerializeField]float delay;
    [SerializeField]bool initInZeroPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (initInZeroPos)transform.position = new Vector3(transform.position.x,0,transform.position.z);
        pos_to_instance = pos_to_instance ? pos_to_instance : transform;
        transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
        StartCoroutine(SpawnWDelay());
    }

    IEnumerator SpawnWDelay()
    {
        yield return new WaitForSeconds(delay);
        Instantiate(prefab_to_instance,pos_to_instance.position,pos_to_instance.rotation);
    }

}
