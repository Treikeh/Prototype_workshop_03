using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 400f;
    public float fireRate = 0.25f;
    public Transform muzzle;
    public GameObject projectilePrefab;

    private Vector2 moveInput;
    private Rigidbody2D rBody;
    private Camera mainCam;


    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;
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
        // Get mouse position
        Vector3 mousePos = Input.mousePosition;
        muzzle.transform.position = mainCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, mainCam.nearClipPlane + 2f));
    }
}
