using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [Header("Configuraci�n de muerte")]
    [SerializeField] private float deathYPosition = -10f;
    [SerializeField] private Animator playerAnimator; // Asigna esto en el Inspector
    [SerializeField] private string deathAnimationTrigger = "P_Death"; // Nombre del trigger
    [SerializeField] private float delayBeforeRespawn = 1f; // Tiempo de animaci�n

    void Start()
    {
        // Si no asignaste manualmente, lo busca autom�ticamente
        if (playerAnimator == null)
            playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (transform.position.y < deathYPosition)
            Die();
    }

    void Die()
    {
        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger(deathAnimationTrigger); // Activa la animaci�n
            Invoke(nameof(RestartLevel), delayBeforeRespawn); // Reinicia despu�s de la animaci�n
        }
        else
        {
            RestartLevel(); // Si no hay animador, reinicia directamente
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia la escena
    }
}