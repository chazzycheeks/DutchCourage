using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health = 10;
    Canonballs canonballSpawner;

    private void Start()
    {
        canonballSpawner = FindAnyObjectByType<Canonballs>();
    }
    private void Update()
    {
        if (health == 0)
        {
            canonballSpawner.isFalling = false;
        }
    }
    public void TakeOneDamage()
    {
        health--;
    }

    public void TakeTwoDamage()
    {
        health = health - 2;
    }

    public void TakeThreeDamage()
    {
        health = health - 3;
    }
}
