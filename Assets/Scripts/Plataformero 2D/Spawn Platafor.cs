using UnityEngine;
namespace Assets.Scripts
{

    public class PlatformSpawner : MonoBehaviour
    {
        [Header("Configuración básica")]
        public GameObject platformPrefab;
        public GameObject enemyAPrefab;
        public GameObject enemyBPrefab;
        public float spawnHeight = 5f;
        public float horizontalRange = 5f;
        public int maxPlatforms = 10;
        public float destroyYPosition = -10f;
        public float enemySpawnChance = 0.3f;

        private float lastSpawnedY = 0f;

        void Start()
        {
            for (int i = 0; i < maxPlatforms; i++)
                SpawnPlatform();
        }

        void Update()
        {
            if (Player.instance == null) return;

            if (Player.instance.transform.position.y > lastSpawnedY - 5f)
            {
                SpawnPlatform();
                DestroyOldPlatforms();
            }
        }

        void SpawnPlatform()
        {
            float randomX = Random.Range(-horizontalRange, horizontalRange);
            Vector2 spawnPosition = new Vector2(randomX, lastSpawnedY + spawnHeight);

            GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity, transform);

            if (Random.value < enemySpawnChance)
            {
                Enemy[] enemiesA = Object.FindObjectsByType<Enemy>(FindObjectsSortMode.None);
                Enemy2[] enemiesB = Object.FindObjectsByType<Enemy2>(FindObjectsSortMode.None);
                int totalEnemies = enemiesA.Length + enemiesB.Length;

                if (totalEnemies < 2)
                {
                    GameObject enemyToSpawn = Random.value < 0.5f ? enemyAPrefab : enemyBPrefab;
                    Instantiate(enemyToSpawn, new Vector2(spawnPosition.x, spawnPosition.y + 1f), Quaternion.identity);
                }
            }

            lastSpawnedY += spawnHeight;
        }

        void DestroyOldPlatforms()
        {
            foreach (Transform child in transform)
            {
                if (child.position.y < destroyYPosition)
                    Destroy(child.gameObject);
            }
        }
    }
}