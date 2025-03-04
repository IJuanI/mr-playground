using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;
public class ShuffleList
{
    public static List<T> ShuffleWithLinq<T>(List<T> list)
    {
        System.Random rng = new System.Random();
        return list.OrderBy(_ => rng.Next()).ToList();
    }
}

public class SpawnFurnitureObjects : MonoBehaviour
{
    [TagSelector]
    [SerializeField]string spawnPointTag;
    [SerializeField]ScriptablePrincipalObjects prefabs;
    List<SpawnPoint> availableSpawnPoints = new();
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1);
        List<GameObject> obtainedPoints = new List<GameObject>(GameObject.FindGameObjectsWithTag(spawnPointTag));
        obtainedPoints = ShuffleList.ShuffleWithLinq(obtainedPoints);
        availableSpawnPoints = obtainedPoints.Select(point => point.GetComponent<SpawnPoint>()).ToList();
        CreateObjects(prefabs.principal_objects_prefab);
        CreateObjects(prefabs.generic_objects_prefab);
    }

    void CreateObjects(List<GameObject> current_list)
    {
        foreach(GameObject prefab in current_list)
        {
            SpawnPoint randomPoint = availableSpawnPoints.FirstOrDefault(point => point.spawns.Exists(spawn => spawn.tagSpawn == prefab.tag));
            if(randomPoint != null)
            {
                GameObject result = Instantiate(prefab,randomPoint.transform);
                result.transform.localPosition = randomPoint.GetSpawnInfo(prefab.tag).offset;
                result.transform.localEulerAngles = randomPoint.GetSpawnInfo(prefab.tag).rotation;
                result.transform.SetParent(null);
                result.transform.localScale = Vector3.one;
                
                availableSpawnPoints.Remove(randomPoint);
                Destroy(randomPoint.gameObject);
            }
        }
    }
}
