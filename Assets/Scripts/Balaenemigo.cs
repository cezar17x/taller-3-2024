using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balaenemigo : MonoBehaviour
{
  public float velocidad;
  public int da�o;

    private void Update()
    {
        transform.Translate(Time.deltaTime * velocidad * Vector2.right);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
      if(other.TryGetComponent(out Vidajugador vidaJugador))
            {
            vidaJugador.TomarDa�o(da�o);
            Destroy(gameObject);
            } 
    }
}
