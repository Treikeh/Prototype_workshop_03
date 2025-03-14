using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float lifetime = 5f;


    void Start()
    {
        Rigidbody2D rBody = GetComponent<Rigidbody2D>();
        rBody.AddForce(transform.up * moveSpeed, ForceMode2D.Impulse);
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Debug.Log("Enemy Hit");
            Events.enemyKilled?.Invoke(5);
        }
    }
}
