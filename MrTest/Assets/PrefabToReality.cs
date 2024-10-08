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

        Bounds? nil_anchor_bound = anchor.VolumeBounds;
        if(nil_anchor_bound.HasValue)
        {
            Bounds anchor_bound = nil_anchor_bound.Value;
            GameObject closest = prefabs[0];
            float smalles_dif = Mathf.Infinity;

            Debug.Log("anchor" + anchor_bound.size);

            for(int i=0;i<pref_renders.Count;i++)
            {
                var a = pref_renders[i];
                var b = a.GetComponent<Renderer>();
                var c = b.bounds;
                Debug.Log("bounds "+ c.size);
                var bounds = Utilities.GetPrefabBounds(pref_renders[i]);
                Debug.Log("Utility bounds" + bounds);
                if(!bounds.HasValue)
                {
                    continue;
                }
                float diff = Mathf.Abs((float)(anchor_bound.size.magnitude - bounds.Value.size.magnitude));
                Debug.Log("Diff " + i + " " + diff);
                if(smalles_dif > diff)
                {
                    smalles_dif = diff;
                    closest = prefabs[i];
                }
            }
            return closest;
        }


        return null;
        
    }
}
