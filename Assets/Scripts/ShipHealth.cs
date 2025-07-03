using System.Collections;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    public int shipHealth;
    private ShipSpawner shipSpawner;
    public Animator enemyShip;
    public Animator shipHitAnim;
    public Animator shipFire;

    private AudioManager audioManager;

    private void Start()
    {
        shipHealth = 2;
        shipSpawner = FindAnyObjectByType<ShipSpawner>();
        audioManager = FindAnyObjectByType<AudioManager>();

    }
    public void ShipFire()
    {
        //if (shipFire.gameObject.activeSelf) shipFire.gameObject.SetActive(true);
        shipFire.SetTrigger("fire");
        audioManager.PlayCannon();
    }
    public void ShipHit()
    {
        if (shipHitAnim == null) { return; }
        shipHitAnim.SetTrigger("hit");
        audioManager.PlayEnemyHit();
    }
    public IEnumerator DestroyShip()
    {
        //if (shipSpawner.ships.Count == 0)
        //{
        //    yield return null;
        //}
        Debug.Log("shipisdestroyed");
        enemyShip.SetTrigger("destroy");
        audioManager.PlaySink();
        yield return new WaitForSeconds(2f);
        shipSpawner.ships.Remove(this);

        Destroy(gameObject);
    }
}
