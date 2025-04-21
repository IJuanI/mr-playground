using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class RemoveInteractableCollider : MonoBehaviour
{
    [SerializeField]int ignoreLayer;
    [SerializeField]HandGrabInteractable handGrab;

    private void Start() {
        StartCoroutine(check());
        //THIS DOSEN'T WORK, THE handGrab.colliders its read only.
    }

    IEnumerator check()
    {
        yield return new WaitForEndOfFrame();
        List<Collider> listColliders =  new List<Collider>(handGrab.Colliders);
    }

}
