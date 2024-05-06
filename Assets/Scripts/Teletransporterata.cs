using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransporterata : MonoBehaviour
{
    public GameObject teleportEffectPrefab; // Prefab del efecto de teletransporte
    public Transform[] teleportPoints; // Puntos de teletransporte
    public float timeBetweenTeleports = 5f; // Tiempo entre teletransportes
    public float teleportDuration = 1f; // Duración del efecto de teletransporte

    private int currentTeleportPointIndex = 0; // Índice del punto de teletransporte actual
    private float lastTeleportTime; // Tiempo del último teletransporte
    private bool isTeleporting; // Indica si el enemigo está actualmente teletransportándose

    void Start()
    {
        // Inicializar el tiempo del último teletransporte
        lastTeleportTime = Time.time;
    }

    void Update()
    {
        // Verificar si es tiempo de teletransportarse nuevamente
        if (!isTeleporting && Time.time - lastTeleportTime > timeBetweenTeleports)
        {
            // Teletransportarse a un nuevo punto
            Teleport();
        }
    }

    void Teleport()
    {
        isTeleporting = true;

        // Reproducir efecto de teletransporte
        if (teleportEffectPrefab != null)
        {
            Instantiate(teleportEffectPrefab, transform.position, Quaternion.identity);
        }

        // Desactivar al enemigo durante la duración del efecto de teletransporte
        gameObject.SetActive(false);

        // Cambiar al siguiente punto de teletransporte
        currentTeleportPointIndex = (currentTeleportPointIndex + 1) % teleportPoints.Length;

        // Teletransportar al enemigo al nuevo punto después de la duración del efecto
        Invoke("CompleteTeleport", teleportDuration);
    }

    void CompleteTeleport()
    {
        // Teletransportar al enemigo al nuevo punto
        transform.position = teleportPoints[currentTeleportPointIndex].position;

        // Reactivar al enemigo
        gameObject.SetActive(true);

        // Actualizar el tiempo del último teletransporte
        lastTeleportTime = Time.time;

        // Indicar que el teletransporte ha terminado
        isTeleporting = false;
    }
}
