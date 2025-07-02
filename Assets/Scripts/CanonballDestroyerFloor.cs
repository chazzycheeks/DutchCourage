using UnityEngine;

public class CanonballDestroyerFloor : MonoBehaviour
{
   
    public HealthManager HealthManager;
    public Animator hit;
    public ScoreManager scoreManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit.SetTrigger("shipHit");
        Destroy(collision.gameObject);
        if (scoreManager.score > 50)
        {
            HealthManager.TakeTwoDamage();
        }
        
        else HealthManager.TakeOneDamage();
    }

  
}
