using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [Header("Configuración de muerte")]
    [SerializeField] private float deathYPosition = -10f;
    [SerializeField] private Animator playerAnimator; // Asigna esto en el Inspector
    [SerializeField] private string deathAnimationTrigger = "P_Death"; // Nombre del trigger
    [SerializeField] private float delayBeforeRespawn = 1f; // Tiempo de animación

    void Start()
    {
        // Si no asignaste manualmente, lo busca automáticamente
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
            playerAnimator.SetTrigger(deathAnimationTrigger); // Activa la animación
            Invoke(nameof(RestartLevel), delayBeforeRespawn); // Reinicia después de la animación
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