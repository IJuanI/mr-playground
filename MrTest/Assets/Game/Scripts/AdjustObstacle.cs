using UnityEngine;
using Unity.AI.Navigation;
using UnityEngine.AI;

public class AdjustObstacle : MonoBehaviour
{
    NavMeshObstacle obstacle;

    void Start()
    {
        obstacle = GetComponent<NavMeshObstacle>();

        Vector3 size_bound = GetComponent<MeshFilter>().mesh.bounds.size;
        size_bound = new Vector3(size_bound.x * transform.parent.localScale.x, size_bound.y,size_bound.z * transform.parent.localScale.z);
        obstacle.size = size_bound;    
    }

}
