using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneObjects", menuName = "ScriptableObjects/GameScriptables/Objects")]
public class ScriptablePrincipalObjects : ScriptableObject
{
    public List<GameObject> principal_objects_prefab;
    public List<GameObject> generic_objects_prefab;
}
