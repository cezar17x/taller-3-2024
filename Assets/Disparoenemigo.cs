using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparoenemigo : MonoBehaviour
{
 public Transform controladorDisparo;
 public float distanciaLinea;
 public LayerMask capaJugador;
 public bool jugadorEnRango;



    private void Update() 
        {
        jugadorEnRango = Physics2D.Raycast(controladorDisparo.position, transform.right, distanciaLinea, capaJugador);

        if (jugadorEnRango) { }
        }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;


    }

}
