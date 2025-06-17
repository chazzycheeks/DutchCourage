using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    public int shipHealth;
    Canonballs canonballs;

    private void Start()
    {
        shipHealth = 3;
        canonballs = FindAnyObjectByType<Canonballs>();

        Invoke("CanonballSpawner", Random.Range(3, 5));
    }

    private void CanonballSpawner()
    {
        Debug.Log("yes");
        canonballs.SpawnCanonball();
        Invoke("CanonballSpawner", Random.Range(3, 5));
    }

    public void DestroyShip()
    {
        Destroy(gameObject);
    }
}
