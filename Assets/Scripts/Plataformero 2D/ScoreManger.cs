using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Assets.Scripts
{
    public class ScoreManager : MonoBehaviour
    {
        [Header("Configuración")]
        public Text scoreText; // Asigna un UI Text en la escena
        public float pointsPerUnit = 1f; // Puntos por unidad de altura
        public float winScore = 15f; // Puntos necesarios para ganar

        private float score = 0f;
        private float lastHeight = 0f;

        void Start()
        {
            if (scoreText != null)
                scoreText.text = "Puntos: 0";
        }

        void Update()
        {
            if (Player.instance == null) return;

            float currentY = Player.instance.transform.position.y;

            if (currentY > lastHeight)
            {
                float newPoints = (currentY - lastHeight) * pointsPerUnit;
                score += newPoints;
                lastHeight = currentY;

                UpdateScoreUI();
            }

            if (score >= winScore)
            {
                WinGame();
            }
        }

        void UpdateScoreUI()
        {
            if (scoreText != null)
                scoreText.text = " " + Mathf.RoundToInt(score);
        }

        void WinGame()
        {
            Debug.Log("¡GANASTE!");
            if (scoreText != null)
                scoreText.text = "¡GANASTE!";

            // Cargar la escena de victoria
            SceneManager.LoadScene("Win Plataformero");
        }
    }
}