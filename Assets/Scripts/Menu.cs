using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }
    public void Salir()
    {
        Console.WriteLine("Saliendo del juego..."); // Salir del Juego
        Application.Quit();
    }
}
