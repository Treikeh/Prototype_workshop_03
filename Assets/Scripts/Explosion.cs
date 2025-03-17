using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        // Destroy explosion after a delay
        Destroy(gameObject, 0.7f);
    }
}
