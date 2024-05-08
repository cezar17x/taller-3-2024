using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pantallainicio : MonoBehaviour
{
    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    public void ComenzarJuego()
    {
        SceneManager.LoadScene("NombreDeTuEscenaDeJuego");
    }
}