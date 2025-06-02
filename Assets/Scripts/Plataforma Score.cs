using UnityEngine;

public class Platform : MonoBehaviour
{
    private bool wasTouched = false; // Para evitar repetir el puntaje

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !wasTouched)
        {
            ScoreManager.Instance.AddScore(1); // Suma 1 punto al jugador
            wasTouched = true; // Marca la plataforma como ya contada
        }
    }
}
