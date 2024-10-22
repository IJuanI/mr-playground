using UnityEngine;

public class ChangeRenderOrder : MonoBehaviour
{
    public Material targetMaterial; // Material al que deseas cambiar el order render

    public int renderQueue = 3000; // Valor del render queue, por ejemplo: 3000 es para Opaque

    void Start()
    {
        if (targetMaterial != null)
        {
            // Cambiar el order de renderizado
            targetMaterial.renderQueue = renderQueue;
            Debug.Log($"Render queue of {targetMaterial.name} changed to {renderQueue}");
        }
        else
        {
            Debug.LogWarning("Target material is not assigned!");
        }
    }
}
