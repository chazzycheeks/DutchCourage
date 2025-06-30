using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ShipHealth shipHealth;
    public GameObject cannonball;

   /* private void Start()
    {
        cannonball = GameObject.FindGameObjectWithTag("Cannonball");
        Physics2D.IgnoreCollision(cannonball.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }*/

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            return;
        }
        var gravity = gameObject.GetComponent<Rigidbody2D>();
        gravity.gravityScale = -4;
    }*/

}
