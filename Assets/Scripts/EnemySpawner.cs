using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnDelay = 1f;
    public GameObject enemy;

    private float spawnTimer = 0f;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnDelay)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
