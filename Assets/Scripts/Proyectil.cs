using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public int damage;
    public GameObject impactPrefab;
    public float velocidadBala;
    RaycastHit2D hit;
    public Rigidbody2D rb2d;

    Vector3 posicionAnterior;
    SonidosGameObject sonidosGO;
    public bool puedeRebotar;
    public float vida;
    float t;

    public int cantidadRebotes;
    int rebotes;
    private void Awake()
    {
        sonidosGO = GetComponent<SonidosGameObject>();
    }

    IEnumerator Start()
    {
        posicionAnterior = transform.position;
        yield return new WaitForSeconds(10);

        Destroy(gameObject);
    }

    private void Update()
    {
        t += Time.deltaTime;

        if(t >= vida)
        {
            Destroy(gameObject);
        }


        Vector2 direccion = (transform.position - posicionAnterior);
        posicionAnterior = transform.position;

        hit = Physics2D.Raycast(transform.position, direccion.normalized, direccion.magnitude);

        if(hit.collider != null)
        {
            if (hit.transform.GetComponent<Damagable>() != null)
                hit.transform.GetComponent<Damagable>().TakeDamage(damage);

            if (impactPrefab)
                Instantiate(impactPrefab, hit.point, Quaternion.identity);

            sonidosGO.ReproducirSonido();

            // Si la bala toco un enemigo entonces se destruye
            if(hit.transform.GetComponent<EsEnemigo>())
            {
                Destroy(gameObject);
            }
            //si la bala toca el boto tmb se destruye
            if (hit.transform.GetComponent<EsBoton>())
            {
                Destroy(gameObject);
            }



            if (puedeRebotar)
            {
                //rotar la bala
                Vector2 direccionNueva = Vector2.Reflect(transform.right, hit.normal);
                transform.right = direccionNueva;
                rebotes++;
                if(rebotes > cantidadRebotes)
                {
                    Destroy(gameObject);
                }

            }

            //Destroy(gameObject);
        }

        

        //transform.Translate(transform.right * velocidadBala * Time.deltaTime, Space.World);
    }

    private void FixedUpdate()
    {
        rb2d.velocity = transform.right * velocidadBala;
    }




}
