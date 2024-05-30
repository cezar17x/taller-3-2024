using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    public void ComenzarJuego()
    {
        SceneManager.LoadScene("level 1");
    }
    public void Irainicio()
    {
        SceneManager.LoadScene("pantallainicio");
    }
    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}