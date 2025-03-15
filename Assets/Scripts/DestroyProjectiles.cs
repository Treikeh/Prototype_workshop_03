using System;
using UnityEngine;

public class DestroyProjectiles : MonoBehaviour
{
    public String destroyTag = "PlayerProjectile";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == destroyTag)
        {
            Destroy(other.gameObject);
        }
    }
}
