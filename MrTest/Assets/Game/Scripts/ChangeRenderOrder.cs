using UnityEngine;

public class ChangeRenderOrder : MonoBehaviour
{
    [SerializeField]bool overrideMaterial;
    [SerializeField]MeshRenderer meshRenderer;
    public Material targetMaterial; 

    public int renderQueue = 3000;

    void Start()
    {
        if (targetMaterial != null)
        {
            if(overrideMaterial)
            {
                Material newMat = new(targetMaterial)
                {
                    renderQueue = renderQueue
                };
                meshRenderer.material = newMat;
            }
            else
            {

                targetMaterial.renderQueue = renderQueue;
            }
            Debug.Log($"Render queue of {targetMaterial.name} changed to {renderQueue}");
        }
        else
        {
            Debug.LogWarning("Target material is not assigned!");
        }
    }
}
