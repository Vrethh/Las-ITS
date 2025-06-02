using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public GameObject instructionsPanel;

    public void StartGame()
    {
        instructionsPanel.SetActive(false); // Oculta el panel
        Time.timeScale = 1f; // Reanuda el juego
    }
}