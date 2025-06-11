using System.Collections.Generic;
using UnityEngine;

public class Canonballs : MonoBehaviour
{
    [SerializeField] private List<Transform> canonballSpawnPoints =new();
    public GameObject CanonballPrefab;
    
    private float ballDelay;
    public bool isFalling = true;
    private void Start()
    {
        SpawnCanonball();
    }
    private void SpawnCanonball()
    {
        if (isFalling == false)
        {
            return;
        }
        int canonballSpawner = Random.Range(0, canonballSpawnPoints.Count);
        Instantiate(CanonballPrefab, canonballSpawnPoints[canonballSpawner]);
        ballDelay = Random.Range(3, 5);
        Invoke(nameof(SpawnCanonball), ballDelay);

      
    }
}
