using UnityEngine;

public class SquareEnemyBehavior : MonoBehaviour
{
    public float moveSpeed = 100f;
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
        Vector2 moveDir = (player.transform.position - transform.position).normalized;
        rBody.linearVelocityX = moveDir.x * moveSpeed * Time.fixedDeltaTime;
        rBody.linearVelocityY = moveDir.y * moveSpeed * Time.fixedDeltaTime;
    }
}
