using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health = 10;
    Canonballs canonballSpawner;

    private void Start()
    {
        canonballSpawner = GetComponent<Canonballs>();
    }
    private void Update()
    {
        if (health == 0)
        {
            canonballSpawner.isFalling = false;
        }
    }
    private void TakeOneDamage()
    {
        health--;
    }

    private void TakeTwoDamage()
    {
        health = health - 2;
    }
}
