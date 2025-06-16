using UnityEngine;

public class CanonballDestroyerSky : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

    }
}
