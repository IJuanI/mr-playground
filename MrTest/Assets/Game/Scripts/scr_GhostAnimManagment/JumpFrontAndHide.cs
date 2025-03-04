using System.Collections;
using UnityEngine;

public class JumpFrontAndHide : MonoBehaviour
{
    public float moveDistance = 2f; // Distancia de movimiento
    public float moveSpeed = 2f; // Velocidad de movimiento

    private bool isMoving = false; // Para evitar múltiples llamadas

    public void MoveForward()
    {
        if (!isMoving)
        {
           // GhostManager.isActiveGhost = true;
            StartCoroutine(Move(transform.position + transform.forward * moveDistance));
        }
    }

    public void MoveBackward()
    {
        if (!isMoving)
        {
           // GhostManager.isActiveGhost = false;
            StartCoroutine(Move(transform.position - transform.forward * moveDistance,true));
        }
    }

    private IEnumerator Move(Vector3 targetPosition, bool isBack = false)
    {
        isMoving = true;
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        float duration = moveDistance / (isBack?moveSpeed/2:moveSpeed); // Calcula cuánto tardará

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Espera al siguiente frame
        }

        transform.position = targetPosition; // Asegura que llega al destino exacto
        isMoving = false;
    }
}
