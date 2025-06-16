using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public List<Transform> spawns = new();
    public GameObject shipPrefab;

    private void Update()
    {
       // SpawnShip();
    }

    private IEnumerator SpawnShip()
    {
       // int shipSpawns = spawns.Count;
        foreach (Transform shipSpawner in spawns)
        {
            if (shipSpawner == null)
            {
                Instantiate(shipPrefab);
            }
            else if (shipSpawner != null)
            {
              //find an emtpy one, if there are no empty ones, wait 10 seconds, return to the start of the method
            }
            yield return new WaitForSeconds(10f);
        }
    }
}
