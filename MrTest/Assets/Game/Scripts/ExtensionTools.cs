using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GenericStructTwoParams<Tkey,TValue>
{
    public Tkey key;
    public TValue value;
}
public static class ExtensionTools
{
    public static Dictionary<TKey,TValue> CreateDictionary<TKey,TValue>(this List<GenericStructTwoParams<TKey,TValue>> list)
    {
        Dictionary<TKey,TValue> genericDictionary = new();
        foreach (var item in list)
        {
            genericDictionary[item.key] = item.value;
        }

        return genericDictionary;
    } 
}
