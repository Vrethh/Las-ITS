
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Text scoretxt;
    public float jump = 7f;
    private int score;
    internal static object instance;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(0, jump);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            score++;
            scoretxt.text = score.ToString();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
public class ScoreManager : MonoBehaviour
{
 public Text scoreText;        // Muestra la puntuación
    public Text winText;          // Nuevo: muestra "¡Ganaste!"
    private int currentScore;     // Variable para almacenar la puntuación
    internal static object Instance;

    void Start()
    {
        currentScore = 0; // Inicializar la puntuación
        UpdateScoreText(); // Actualizar el texto inicialmente
        if (currentScore >= 15 && winText != null)
        {
            winText.text = "¡Ganaste!";
        }

    }

    // Función para sumar puntos
    public void AddScore(int points)
    {
        currentScore += points;
        UpdateScoreText(); // Actualizar el texto
    }

    // Función para actualizar el texto de la puntuación
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScore.ToString(); // Mostrar la puntuación en el texto
    }
}

