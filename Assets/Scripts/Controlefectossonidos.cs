using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlefectossonidos : MonoBehaviour
{
    public Transform player; // Asigna el transform del jugador en el inspector
    public AudioSource audioSource;
    public float maxDistance = 10f; // Distancia máxima a la que el sonido será completamente atenuado

    void Update()
    {
        // Calcula la distancia entre el jugador y este objeto
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Calcula el volumen basado en la distancia
        float volume = 1f - Mathf.Clamp01(distanceToPlayer / maxDistance);

        // Aplica el volumen al Audio Source
        audioSource.volume = volume;
    }
}