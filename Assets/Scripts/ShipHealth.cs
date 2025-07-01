using System.Collections;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    public int shipHealth;
    private ShipSpawner shipSpawner;
    public Animator enemyShip;
    public Animator shipHitAnim;
    public Animator shipFire;


    private void Start()
    {
        shipHealth = 2;
        shipSpawner = FindAnyObjectByType<ShipSpawner>();

    }
    public void ShipFire()
    {
        if (shipFire.gameObject.activeSelf) shipFire.gameObject.SetActive(true);
        shipFire.SetTrigger("fire");
    }
    public void ShipHit()
    {
        shipHitAnim.SetTrigger("hit");
    }
    public IEnumerator DestroyShip()
    {
        if (shipSpawner.ships.Count == 0)
        {
            yield return null;
        }
        Debug.Log("shipisdestroyed");
        enemyShip.SetTrigger("destroy");
        yield return new WaitForSeconds(2f);
        shipSpawner.ships.Remove(this);

        Destroy(gameObject);
    }
}
