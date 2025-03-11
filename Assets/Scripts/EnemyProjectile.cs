using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lifetime = 5f;


    void Start()
    {
        Rigidbody2D rBody = GetComponent<Rigidbody2D>();
        rBody.AddForce(transform.right * moveSpeed, ForceMode2D.Impulse);
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player hit");
        }
    }
}
