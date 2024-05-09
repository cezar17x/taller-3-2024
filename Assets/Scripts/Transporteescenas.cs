using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Transporteescenas : MonoBehaviour
{
    public string nombreDeEscenaACambiar; // Nombre de la escena a la que quieres cambiar

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Verifica si el jugador entró en el área específica
        {
            // Cambiar a la nueva escena
            SceneManager.LoadScene(nombreDeEscenaACambiar);
        }
    }
}
