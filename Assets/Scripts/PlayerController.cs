using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 400f;
    public float fireRate = 0.25f;
    public Transform muzzle;
    public GameObject projectilePrefab;

    private bool canShoot = true;
    private Camera mainCam;


    void Start()
    {
        mainCam = Camera.main;
    }

    void FixedUpdate()
    {
        // Move player to mouse position
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0f);

        // Spawn projectiles when pressing left mouse button
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            canShoot = false;
            Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);
            Invoke("ResetCanShoot", fireRate);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            // Take Damage
            Debug.Log("Player Hit");
        }
    }

    void ResetCanShoot()
    {
        canShoot = true;
    }
}
