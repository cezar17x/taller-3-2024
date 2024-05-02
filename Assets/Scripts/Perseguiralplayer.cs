using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguiralplayer : MonoBehaviour

{
 public Transform playertransform;
    public float velocidadenemy;
    public float distanciaminima;
    public Rigidbody2D rbenemigo;
    private float distancia;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       distancia = Vector3.Distance(playertransform.position,transform.position);
        // si la distancia entre el player y el enemigo es  menor o igual a la distancia minima
        // entonces perseguir al player

        if(distancia <= distanciaminima) 
        {
            transform.position = Vector3.MoveTowards(transform.position, playertransform.position,velocidadenemy*Time.deltaTime);  
        }
    }
}
