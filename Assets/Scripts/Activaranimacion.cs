using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activaranimacion : MonoBehaviour
{
    public Animator animator; // Referencia al componente Animator de la animación que quieres reproducir

    private void Start()
    {
        // Asegúrate de que el animator esté inicializado
        if (animator == null)
        {
            animator = GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogError("El Animator no está asignado en el Inspector y no se pudo encontrar en el GameObject.");
            }
        }
    }

    private void OnDestroy()
    {
        // Reproduce la animación cuando el enemigo se destruya
        if (animator != null)
        {
            animator.Play("levantamiento de puerta 4"); // Reemplaza "NombreDeTuAnimacion" con el nombre de la animación que quieres reproducir
        }
    }
}