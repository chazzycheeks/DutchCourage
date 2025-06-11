using UnityEngine;

public class CanonballDestroyer : MonoBehaviour
{
    [SerializeField] private Collider2D shipFloor;
    [SerializeField] private Collider2D sky;

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }*/

    //tag both colliders
    //if a canonball collides with the sky one, delete
    //if a cannonball collides with the floor one, delete & take damage
}
