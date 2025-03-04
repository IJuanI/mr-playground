using System;
using System.Collections.Generic;
using System.Linq;
using Meta.XR.MRUtilityKit;
using Unity.Mathematics;
using UnityEngine;

public class PrefabToReality : AnchorPrefabSpawner
{
    List<GameObject> prefabsRenders = new();

    public override Vector3 CustomPrefabAlignment(Bounds anchorVolumeBounds, Bounds? prefabBounds)
    {
        (Vector3, Vector3) tuple = (default(Vector3), default(Vector3));
        Vector3 localScale = new Vector3(anchorVolumeBounds.size.x / prefabBounds.Value.size.x, anchorVolumeBounds.size.z / prefabBounds.Value.size.y, anchorVolumeBounds.size.y / prefabBounds.Value.size.z);

        if (prefabBounds.HasValue)
        {
            Vector3 center2 = prefabBounds.Value.center;
            Vector3 min = prefabBounds.Value.min;
            tuple.Item1 = new Vector3(center2.x, center2.z, min.y);
        }

        tuple.Item2 = anchorVolumeBounds.center;
        tuple.Item2.z = anchorVolumeBounds.min.z;
        
        tuple.Item1.x *= localScale.x;
        tuple.Item1.y *= localScale.z;
        tuple.Item1.z *= localScale.y;

        Vector3 result = tuple.Item2 - tuple.Item1;
        result.x = 0;
        result.y = 0;
        return result;
    }
    
    public override GameObject CustomPrefabSelection(MRUKAnchor anchor, List<GameObject> prefabs)
    {
        InitializePrefabsRenderers(prefabs);
        GameObject closest = prefabs[0];
        float smallDifference = Mathf.Infinity;

        float diff = 0;
        float min;
        float max;
        
        for(int i=0;i<prefabsRenders.Count;i++)
        {
            var bounds = prefabsRenders[i].GetComponent<GridSliceResizer>().OriginalMesh.bounds;
            //filtrar la forma del objeto, si es mas largo o ancho que alto el objeto debe ser un mueble horizontal.
            //caso contrario un mueble vertical.
            if(!anchor.PlaneRect.HasValue && IsVertical(bounds.size) != IsVertical(anchor.VolumeBounds.Value.size,true))
            {
                continue;
            }

            //Is Plane.
            //calculates the multiplication vector to make the prefab bound size the same as the mesh bound
            //then use the vector to set the prefab wich needs less deformation.
            if(anchor.PlaneRect.HasValue)
            {
                Vector2 size = anchor.PlaneRect.Value.size;
                Vector2 multipliers = new Vector2(size.x/bounds.size.x,size.y/bounds.size.y);

                min = Mathf.Min(multipliers.x,multipliers.y);
                max = Mathf.Max(multipliers.x,multipliers.y);
                diff = max-min;
            }
            else
            {

                Vector3 size = anchor.VolumeBounds.Value.size;
                Vector3 multipliers = new Vector3(size.x/bounds.size.x,size.z/bounds.size.y,size.y/bounds.size.z);

                min = Mathf.Min(multipliers.x,multipliers.y,multipliers.z);
                max = Mathf.Max(multipliers.x,multipliers.y,multipliers.z);
                diff = max-min;
            }

            if(smallDifference > diff)
            {
                smallDifference = diff;
                closest = prefabs[i];
            }
        }
        return closest;
         
    }

    void InitializePrefabsRenderers(List<GameObject> prefabs)
    {
        prefabsRenders.Clear();
        for(int i=0; i<prefabs.Count; i++)
        {
            GameObject maxBoundsPrefabs = prefabs[i].GetComponentsInChildren<MeshRenderer>()
                                        .Select(p => p.gameObject)
                                        .Single(go => go.tag == "BaseModel");

            if(maxBoundsPrefabs != null)
            {
                prefabsRenders.Add(maxBoundsPrefabs);
            }
        }
    }

    bool IsVertical(Vector3 size, bool is_anchor_bound = false)
    {
        return is_anchor_bound? size.z * 1.3f > size.x && size.z * 1.3f > size.y : size.y * 1.3f > size.x && size.y * 1.3f > size.z;
    }
}
