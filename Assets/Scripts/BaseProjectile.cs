using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float lifetime = 5f;

    void Start()
    {
        Rigidbody2D rBody = GetComponent<Rigidbody2D>();
        rBody.AddForce(transform.right * moveSpeed, ForceMode2D.Impulse);
        Destroy(gameObject, lifetime);
    }
}
