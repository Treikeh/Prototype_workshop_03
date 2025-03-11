using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 400f;
    public Transform muzzle;
    public GameObject projectilePrefab;

    private Vector2 moveInput;
    private Rigidbody2D rBody;


    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movement input
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput = moveInput.normalized;

        // Shoot input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);
        }
    }

    void FixedUpdate()
    {
        rBody.linearVelocityX = moveInput.x * moveSpeed * Time.fixedDeltaTime;
        rBody.linearVelocityY = moveInput.y * moveSpeed * Time.fixedDeltaTime;
    }
}
