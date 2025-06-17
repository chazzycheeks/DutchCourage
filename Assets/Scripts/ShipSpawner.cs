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

    public IEnumerator shipSpawnCoroutine;
   
    private void Start()
    {
        if (shipSpawnCoroutine == null)
        {
            shipSpawnCoroutine = SpawnShip();
            StartCoroutine(shipSpawnCoroutine); 
        }
    }

    private IEnumerator SpawnShip()
    {
       // int shipSpawns = spawns.Count;
        foreach (ShipSpawnPoint shipSpawner in spawns)
        {
            if (shipSpawner.currentObject == null)
            {
                GameObject newShip = Instantiate(shipPrefab, shipSpawner.spawnPoint.position, Quaternion.identity);
                shipSpawner.currentObject = newShip;
                //canonballs.SpawnCanonball();
                break;
            }
            
        }
        yield return new WaitForSeconds(10f);

        shipSpawnCoroutine = null;
    }

}
