using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigospawner : MonoBehaviour
{
    public GameObject prefabAInstanciar;

    private void OnDestroy()
    {
        if (prefabAInstanciar != null)
        {
            Instantiate(prefabAInstanciar, transform.position, Quaternion.identity);
        }
    }
}