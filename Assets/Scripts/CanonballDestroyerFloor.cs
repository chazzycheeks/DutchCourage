using UnityEngine;

public class CanonballDestroyerFloor : MonoBehaviour
{
    //[SerializeField] private List<BoxCollider2D> floorDestroyers = new List<BoxCollider2D>();
    public HealthManager HealthManager;
    public Animator hit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit.SetTrigger("shipHit");
        Destroy(collision.gameObject);
        HealthManager.TakeOneDamage();
    }

  
}
