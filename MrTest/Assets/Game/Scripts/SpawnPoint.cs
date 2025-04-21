using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public struct SpawnWithOffset
{
    [TagSelector] public string tagSpawn;
    public Vector3 offset;
    public Vector3 rotation;
    public Vector3 limitScale;
}
public class SpawnPoint : MonoBehaviour
{
    public Transform scaleParent;
    public List<SpawnWithOffset> spawns = new();
    Dictionary<string,SpawnWithOffset> dictionarySpawn = new();

    private void Start() {

        spawns.RemoveAll(item => item.limitScale.x > scaleParent.localScale.x 
        || item.limitScale.y > scaleParent.localScale.y 
        || item.limitScale.z > scaleParent.localScale.z);
        
        spawns.ForEach(spawn =>
        {
            dictionarySpawn.Add(spawn.tagSpawn,spawn);
        });
    }

    public SpawnWithOffset GetSpawnInfo(string tag)
    {
        return dictionarySpawn[tag];
    }
}
