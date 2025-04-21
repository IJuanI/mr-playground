using UnityEngine;

public class ChangeMatColor : MonoBehaviour
{
    [SerializeField]Renderer mat;
    [SerializeField]Color color_to_change;

    public void ChangeColor()
    {
        mat.material.SetColor("_BaseColor", color_to_change);
    }


}
