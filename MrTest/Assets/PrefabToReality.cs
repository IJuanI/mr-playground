using System.Collections.Generic;
using System.Linq;
using Meta.XR.MRUtilityKit;
using Unity.Mathematics;
using UnityEngine;

public class PrefabToReality : AnchorPrefabSpawner
{
    public override GameObject CustomPrefabSelection(MRUKAnchor anchor, List<GameObject> prefabs)
    {
        List<GameObject> pref_renders = new();
        for(int i=0; i<prefabs.Count; i++)
        {
            GameObject max_bound_pref = prefabs[i].GetComponentsInChildren<MeshRenderer>().Select(p => p.gameObject).Single(go => go.tag == "BaseModel");
            if(max_bound_pref != null)
            {
                pref_renders.Add(max_bound_pref);
            }
        }

        Bounds? anchor_bound = anchor.VolumeBounds;
        GameObject closest = pref_renders[0];
        float smalles_dif = Mathf.Infinity;

        for(int i=0;i<pref_renders.Count;i++)
        {
            var bounds = Utilities.GetPrefabBounds(pref_renders[i]);
            float diff = Mathf.Abs((float)(anchor_bound?.size.magnitude - bounds?.size.magnitude));
            if(smalles_dif > diff)
            {
                smalles_dif = diff;
                closest = prefabs[i];
            }
        }


        return closest;
    }
}
