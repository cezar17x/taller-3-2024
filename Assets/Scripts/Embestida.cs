using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embestida : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del enemigo
    public float pauseTime = 2f; // Tiempo de espera antes de volver a moverse hacia el jugador

    private Transform playerTransform; // Referencia al transform del jugador
    private bool isMovingTowardsPlayer = true; // Indica si el enemigo se está moviendo hacia el jugador
    private Vector3 initialPosition; // Posición inicial del enemigo

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
            Debug.LogError("No se encontró al jugador. Asegúrate de que el jugador tenga la etiqueta 'Player'.");
        }

        // Guardar la posición inicial del enemigo
        initialPosition = transform.position;
    }

    void Update()
    {
        if (playerTransform != null)
        {
            if (isMovingTowardsPlayer)
            {
                // Calcular la dirección hacia el jugador
                Vector3 directionToPlayer = playerTransform.position - transform.position;

                // Mover el enemigo hacia el jugador
                transform.Translate(directionToPlayer.normalized * moveSpeed * Time.deltaTime);

                // Si el enemigo está cerca del jugador, detenerse y esperar
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
        // Volver a moverse hacia la posición del jugador
        isMovingTowardsPlayer = true;
        transform.position = initialPosition; // Reiniciar la posición del enemigo
    }
}
