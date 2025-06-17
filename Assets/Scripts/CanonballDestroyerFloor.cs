using UnityEngine;

public class CanonballDestroyerFloor : MonoBehaviour
{
    public HealthManager HealthManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        HealthManager.TakeOneDamage();
    }

}
