using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ShipSpawnPoint
{
    public Transform spawnPoint;
    public GameObject currentObject;
}

public class ShipSpawner : MonoBehaviour
{
    public List<ShipSpawnPoint> spawns = new();
    public GameObject shipPrefab;
    //public Canonballs canonballs;

    //A list of all ships currently spawned
    public List<ShipHealth> ships = new();

    public IEnumerator shipSpawnCoroutine;
   
    private void Update()
    {
        if (shipSpawnCoroutine == null)
        {
            shipSpawnCoroutine = SpawnShip();
            StartCoroutine(shipSpawnCoroutine); 
        }
    }

    private IEnumerator SpawnShip()
    {
        yield return new WaitForSeconds(2f);
       // int shipSpawns = spawns.Count;
        foreach (ShipSpawnPoint shipSpawner in spawns)
        {
            if (shipSpawner.currentObject == null)
            {
                GameObject newShip = Instantiate(shipPrefab, shipSpawner.spawnPoint.position, Quaternion.identity);
                shipSpawner.currentObject = newShip;

                //Add this new ship to the list of spawned ships
                ships.Add(newShip.GetComponent<ShipHealth>());

                //canonballs.SpawnCanonball();

                break;
            }
            
        }
        yield return new WaitForSeconds(8f);

        shipSpawnCoroutine = null;
    }

}
