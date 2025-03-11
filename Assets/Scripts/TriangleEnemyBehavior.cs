using UnityEngine;

public class TriangleEnemyBehavior : MonoBehaviour
{
    public float moveDistance = 1f;
    public float moveSpeed = 1f;
    public float rotSpeed = 5f;
    public float fireRate = 1f;
    public Transform muzzle;
    public GameObject projectilePrefab;

    private float shootTimer = 0f;
    private Vector2 startingPosition;

    
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startingPosition = transform.position;
    }

    void Update()
    {
        // Move enemy
        Vector2 newPos = startingPosition;
        newPos.x += moveDistance * Mathf.Sin(Time.time * moveSpeed);
        transform.position = newPos;

        // Make enemy look at player
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotSpeed);

        // Shoot timer
        shootTimer += Time.deltaTime;
        if (shootTimer >= fireRate)
        {
            SpawnProjectile();
            shootTimer = 0f;
        }
    }

    void SpawnProjectile()
    {
        Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);
    }
}
