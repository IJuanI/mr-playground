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
        float anchorArea = 0;
        bool isPlane = false;
        
        if(anchor.VolumeBounds.HasValue)
        {
            Vector3 size = anchor.VolumeBounds.Value.size;
            anchorArea = size.x*size.y*size.z;
        }
        else
        if(anchor.PlaneRect.HasValue)
        {
            anchorArea = anchor.PlaneRect.Value.width * anchor.PlaneRect.Value.height;
            Debug.Log("ANCHOR AREA IS "+anchorArea + anchor.PlaneRect.Value.size);
            isPlane = true;
        }

        for(int i=0;i<prefabsRenders.Count;i++)
        {
            var bounds = prefabsRenders[i].GetComponent<GridSliceResizer>().OriginalMesh.bounds;
            //filtrar la forma del objeto, si es mas largo o ancho que alto el objeto debe ser un mueble horizontal.
            //caso contrario un mueble vertical.
            if(!isPlane && IsVertical(bounds.size) != IsVertical(anchor.VolumeBounds.Value.size,true))
            {
                continue;
            }

            float prefabArea = 0;
            prefabArea = isPlane? bounds.size.x * bounds.size.y : bounds.size.x*bounds.size.y*bounds.size.z;
            
            Debug.Log("PREFAB AREA IS "+prefabArea + "PREFAB SIZE IS "+ bounds.size + "prefab is "+prefabs[i].name + isPlane);
            float diff = Mathf.Abs((float)(anchorArea - prefabArea));

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
        Debug.Log("NAME IS  "+ name);
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
        return is_anchor_bound? size.z > size.x && size.z > size.y : size.y > size.x && size.y > size.z;
    }
}
