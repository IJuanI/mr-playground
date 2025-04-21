using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RitualScriptable", menuName = "ScriptableObjects/GameScriptables/Ritual")]
public class ScriptableRitualRequisit : ScriptableObject
{
    public List<RitualStep> steps;
}
