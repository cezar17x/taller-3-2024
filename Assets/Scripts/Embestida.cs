using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embestida : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del enemigo
    public float pauseTime = 2f; // Tiempo de espera antes de volver a moverse hacia el jugador

    private Transform playerTransform; // Referencia al transform del jugador
    private bool isMovingTowardsPlayer = true; // Indica si el enemigo se est� moviendo hacia el jugador
    private Vector3 initialPosition; // Posici�n inicial del enemigo

    void Start()
    {
        // Buscar el GameObject con la etiqueta "Player" y obtener su transform
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("No se encontr� al jugador. Aseg�rate de que el jugador tenga la etiqueta 'Player'.");
        }

        // Guardar la posici�n inicial del enemigo
        initialPosition = transform.position;
    }

    void Update()
    {
        if (playerTransform != null)
        {
            if (isMovingTowardsPlayer)
            {
                // Calcular la direcci�n hacia el jugador
                Vector3 directionToPlayer = playerTransform.position - transform.position;

                // Mover el enemigo hacia el jugador
                transform.Translate(directionToPlayer.normalized * moveSpeed * Time.deltaTime);

                // Si el enemigo est� cerca del jugador, detenerse y esperar
                if (directionToPlayer.magnitude < 0.5f)
                {
                    isMovingTowardsPlayer = false;
                    Invoke("ResumeMovement", pauseTime);
                }
            }
            else
            {
                // Esperar
                // No hacer nada mientras se espera
            }
        }
    }

    void ResumeMovement()
    {
        // Volver a moverse hacia la posici�n del jugador
        isMovingTowardsPlayer = true;
        transform.position = initialPosition; // Reiniciar la posici�n del enemigo
    }
}
