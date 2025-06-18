using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    public int shipHealth;
   /* Canonballs canonballs;*/
    private ShipSpawner shipSpawner;



    private void Start()
    {
        shipHealth = 2;
   /*     canonballs = FindAnyObjectByType<Canonballs>();*/
        shipSpawner = FindAnyObjectByType<ShipSpawner>();

       /* Invoke("CanonballSpawner", Random.Range(3, 5));*/
    }

    //Remove this function
/*    private void CanonballSpawner()
    {
        Debug.Log("yes");
        canonballs.SpawnCanonball(this);
        Invoke("CanonballSpawner", Random.Range(3, 5));
    }*/

    public void DestroyShip()
    {
        //Remove this object from the ShipSpawmer's list of ships
        shipSpawner.ships.Remove(this);

        Destroy(gameObject);
    }
}
