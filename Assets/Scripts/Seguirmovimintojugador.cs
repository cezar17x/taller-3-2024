using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguirmovimintojugador : MonoBehaviour
{
    private Transform playerTransform; // Referencia al transform del jugador

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
    }

    void Update()
    {
        if (playerTransform != null)
        {
            // Calcular la dirección hacia el jugador
            Vector2 directionToPlayer = playerTransform.position - transform.position;

            // Rotar el enemigo para que mire hacia el jugador
            if (directionToPlayer != Vector2.zero)
            {
                float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle - 365, Vector3.forward);
            }
        }
    }
}