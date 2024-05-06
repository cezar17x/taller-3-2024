using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparoenemigo : MonoBehaviour
{
 public Transform controladorDisparo;
 public float distanciaLinea;
 public LayerMask capaJugador;
 public bool jugadorEnRango;
    public float tiempoEntreDisparos;
    public float tiempoUltimoDisparo;
  public GameObject balaenemigo;
  public float tiempoEsperaDisparo;  



    private void Update() 
        {
        jugadorEnRango = Physics2D.Raycast(controladorDisparo.position, transform.right, distanciaLinea, capaJugador);

        if (jugadorEnRango) 
            { 
            if(Time.time > tiempoEntreDisparos + tiempoUltimoDisparo) 
                {
                tiempoUltimoDisparo = Time.time;
                Invoke(nameof(Disparar), tiempoEsperaDisparo);
                
                }
            }
        }

    private void Disparar() 
        { 
        Instantiate(balaenemigo, controladorDisparo.position, controladorDisparo.rotation);
        
        }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorDisparo.position, controladorDisparo.position + transform.right * distanciaLinea);

    }

}
