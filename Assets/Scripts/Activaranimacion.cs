using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activaranimacion : MonoBehaviour
{
    public Animator animator; // Referencia al componente Animator de la animaci�n que quieres reproducir

    private void Start()
    {
        // Aseg�rate de que el animator est� inicializado
        if (animator == null)
        {
            animator = GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogError("El Animator no est� asignado en el Inspector y no se pudo encontrar en el GameObject.");
            }
        }
    }

    private void OnDestroy()
    {
        // Reproduce la animaci�n cuando el enemigo se destruya
        if (animator != null)
        {
            animator.Play("levantamiento de puerta 4"); // Reemplaza "NombreDeTuAnimacion" con el nombre de la animaci�n que quieres reproducir
        }
    }
}