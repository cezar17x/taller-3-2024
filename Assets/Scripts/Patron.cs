using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del enemigo
    public float distance = 10f; // Distancia total que recorre el enemigo

    private Vector3 startPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + Vector3.right * distance; // Mover hacia la derecha
    }

    private void Update()
    {
        // Mover el enemigo hacia el objetivo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Si alcanza el punto de destino, cambiar la dirección
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Cambiar el destino entre el punto de inicio y el punto final
            if (targetPosition == startPosition)
                targetPosition = startPosition + Vector3.right * distance;
            else
                targetPosition = startPosition;
        }
    }
}