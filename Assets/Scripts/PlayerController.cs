using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 400f;
    public float fireRate = 0.25f;
    public int livesRemaning = 3;
    public Transform muzzle;
    public GameObject projectilePrefab;
    public SpriteRenderer playerSprite;
    public AudioSource hitSound;
    public GameObject explosionPrefab;

    private bool canShoot = true;
    private bool isProtected = false;
    private Camera mainCam;


    void Start()
    {
        mainCam = Camera.main;
    }

    void FixedUpdate()
    {
        // Don't move player when game isn't active
        if (GameManager.gameState != GameManager.GameStates.Active)
        {
            return;
        }
        
        if (Input.GetMouseButton(0))
        {
            // Move player to mouse position
            Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
            // Spawn projectiles
            if (canShoot == true)
            {
                canShoot = false;
                Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);
                Invoke("ResetCanShoot", fireRate);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && isProtected == false)
        {
            // Take Damage
            isProtected = true;
            StartCoroutine(PlayerHitFlasing());
            livesRemaning--;
            hitSound.Play();
            if (livesRemaning <= 0)
            {
                // End game when player is killed
                GameManager.EndGame();
                Instantiate(explosionPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    void ResetCanShoot()
    {
        canShoot = true;
    }

    IEnumerator PlayerHitFlasing()
    {
        int flashAmount = 6;
        while (flashAmount > 0)
        {
            playerSprite.color = new Color(0f, 0f, 0f, 0f);
            yield return new WaitForSeconds(.1f);
            playerSprite.color = Color.white;
            yield return new WaitForSeconds(.1f);
            flashAmount --;
            yield return null;
        }
        isProtected = false;
    }
}
