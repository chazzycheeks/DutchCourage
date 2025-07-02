using System.Collections.Generic;
using UnityEngine;

public class Canonballs : MonoBehaviour
{
    [SerializeField] private List<Transform> canonballSpawnPoints =new();
    public List<Transform> warningSpawnPoints =new();
    //public List<Transform> hitSpawnPoints = new();
    public GameObject canonballPrefab;
    public GameObject warningPrefab;
    public GameObject hitPrefab;
    
    private float ballDelay;
    public bool isFalling;

    private ShipSpawner shipSpawner;
    
    
    private bool spawningAllowed = false;  

    private void Start()
    {
        //shipHealth.GetComponent<ShipHealth>();
        isFalling = true;
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
            GameObject newCanonball = Instantiate(canonballPrefab, canonballSpawnPoints[canonballSpawner]);
            
            SpawnWarning(canonballSpawner);

            //Instead of getting the ship health from the ship itself
            //We pick a random ship from the ShipSpawner's list of ships
            //And assign that shipHealth to the new cannonball
            int index = Random.Range(0, shipSpawner.ships.Count);
            newCanonball.GetComponent<Projectile>().shipHealth = shipSpawner.ships[index];
            newCanonball.GetComponent<Projectile>().shipHealth.ShipFire();
        }

            if (shipSpawner.ships.Count == 1)
            {
                ballDelay = 4;
            }
            if (shipSpawner.ships.Count == 2)
            {
                ballDelay = 2.5f;
            }
            if (shipSpawner.ships.Count == 3)
            {
                ballDelay = 1.7f;
            }  

            Invoke(nameof(SpawnCanonball), ballDelay);    
    }

    public void SpawnWarning(int index)
    {
        Instantiate(warningPrefab, warningSpawnPoints[index]);

    }

  
}
