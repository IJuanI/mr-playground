using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
public class RuntimeNavmesh : MonoBehaviour
{
    [SerializeField]NavMeshSurface surface;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CreateNav());
    }

    IEnumerator CreateNav()
    {
        yield return new WaitForSeconds(.1f);
        transform.localScale = new Vector3(transform.localScale.x,.1f,transform.localScale.z);
        surface.BuildNavMesh();
        Destroy(transform.GetChild(0).gameObject);
    }
}
