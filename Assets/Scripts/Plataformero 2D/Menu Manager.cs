using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Configuraci�n de escena")]
    [SerializeField] private string sceneToLoad = "NombreDeTuEscena"; 

    public void StartGame()
    {
        // Carga la escena definida en el Inspector
        SceneManager.LoadScene(sceneToLoad);
    }
}