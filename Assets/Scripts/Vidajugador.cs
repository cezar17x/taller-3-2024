using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidajugador : MonoBehaviour
{
    public int cantidadDeVida;

        public void TomarDa�o(int da�o) 
        { 
        cantidadDeVida -= da�o;
     
            if(cantidadDeVida <= 0) 
            { 
            Destroy(gameObject);
            } 
        
        }
}
