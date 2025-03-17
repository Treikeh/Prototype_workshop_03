using System.Threading;
using UnityEngine;

public class TriangleEnemyBehavior : MonoBehaviour
{
    public float strafeDistance = 1f;
    public float strafeSpeed = 1f;
    public float moveSpeed = 0.5f;
    public float rotSpeed = 5f;
    public float fireRate = 1f;
    public Transform muzzle;
    public GameObject projectilePrefab;
    public GameObject explosionPrefab;

    private float shootTimer = 0f;
    private float strafeTimeOffset = 0.0f;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        strafeTimeOffset = Time.time;
    }

    void Update()
    {
        // Move enemy
        Vector2 newPos = transform.position;
        newPos.x = strafeDistance * Mathf.Sin((Time.time - strafeTimeOffset) * strafeSpeed);
        newPos.y -= moveSpeed * Time.deltaTime;
        transform.position = newPos;

        // Stop here when player is gone
        if (!player)
        {
            return;
        }
        // Make enemy look at player
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotSpeed);

        // Shoot timer
        shootTimer += Time.deltaTime;
        if (shootTimer >= fireRate)
        {
            Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);
            shootTimer = 0f;
        }
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
