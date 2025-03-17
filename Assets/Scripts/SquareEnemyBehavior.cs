using UnityEngine;

public class SquareEnemyBehavior : MonoBehaviour
{
    public float moveSpeed = 100f;
    public GameObject explosionPrefab;

    private GameObject player;
    private Rigidbody2D rBody;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Don't do anything when player is gone
        if (!player)
        {
            return;
        }
        Vector2 moveDir = (player.transform.position - transform.position).normalized;
        rBody.linearVelocityX = moveDir.x * moveSpeed * Time.fixedDeltaTime;
        rBody.linearVelocityY = moveDir.y * moveSpeed * Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Do different things based on what hits it
        switch (other.tag)
        {
            case "Player":
                // Only destroy enemy
                DestroyEnemy();
                break;
            case "PlayerProjectile":
                // Destroy enemy and projectile
                DestroyEnemy();
                Destroy(other.gameObject);
                break;
        }
    }

    void DestroyEnemy()
    {
        GameManager.EnemyKilled(10);
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
