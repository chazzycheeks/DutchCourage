using System.Collections.Generic;
using UnityEngine;

public class Canonballs : MonoBehaviour
{
    [SerializeField] private List<Transform> canonballSpawnPoints =new();
    public GameObject CanonballPrefab;
    
    private float ballDelay;
    public bool isFalling = true;

    private ShipSpawner shipSpawner;
    private bool spawningAllowed = false;  

    private void Start()
    {
        shipSpawner = FindAnyObjectByType<ShipSpawner>();     
        SpawnCanonball();
    }

    private void Update()
    {
        if (shipSpawner.ships.Count == 0)
        {
            spawningAllowed = false ;
        }
        else
        {
            spawningAllowed = true ;
        }
    }


    public void SpawnCanonball()
    {
        if (isFalling == false)
        {
            return;
        }
        if (spawningAllowed == true)
        {
            int canonballSpawner = Random.Range(0, canonballSpawnPoints.Count);
            GameObject newCanonball = Instantiate(CanonballPrefab, canonballSpawnPoints[canonballSpawner]);

            //Instead of getting the ship health from the ship itself
            //We pick a random ship from the ShipSpawner's list of ships
            //And assign that shipHealth to the new cannonball
            int index = Random.Range(0, shipSpawner.ships.Count);
            newCanonball.GetComponent<Projectile>().shipHealth = shipSpawner.ships[index];
        }

        //Have the ball delay be affected by how many items are in the ShipSpawner's list of ships
        if (shipSpawner.ships.Count == 1)
        {
            ballDelay = Random.Range(4, 5);
        }
        if (shipSpawner.ships.Count == 2)
        {
            ballDelay = Random.Range(2.5f, 3);
        }
        if (shipSpawner.ships.Count == 3)
        {
            ballDelay = Random.Range(1, 2);
        }
        Invoke(nameof(SpawnCanonball), ballDelay);

      
    }
}
