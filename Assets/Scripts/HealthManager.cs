using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health = 0;
    Canonballs canonballSpawner;
    [SerializeField] private List<GameObject> backgrounds = new List<GameObject>();
    [SerializeField] private GameObject currentBackground;

    public ScoreManager scoreManager;
    public AudioManager audioManager;

    private void Start()
    {
        canonballSpawner = FindAnyObjectByType<Canonballs>();
        currentBackground = backgrounds[0];
        currentBackground.SetActive(true);
    }
    private void Update()
    {
        if (health >= 11)
        {
            canonballSpawner.isFalling = false;
            scoreManager.GameOver();
        }
        
    }
    public void TakeOneDamage()
    {
        if (health > backgrounds.Count)
        {
            return;
        }
        if (health <= backgrounds.Count)
        {
            if (currentBackground != null)
            {
                currentBackground.SetActive(false);
            }

            audioManager.PlayPlayerHit();
            health++;
            currentBackground = backgrounds[health];
            currentBackground.SetActive(true);

        }
    }

    public void TakeTwoDamage()
    {
        if (health > backgrounds.Count)
        {
            return;
        }
        if (health <= backgrounds.Count)
        {
            if (currentBackground != null)
            {
                currentBackground.SetActive(false);
            }

            audioManager.PlayPlayerHit();
            health = health + 2;
            currentBackground = backgrounds[health];
            currentBackground.SetActive(true);
        }
    }

    public void TakeThreeDamage()
    {
        if (health > backgrounds.Count)
        {
            return;
        }
        if (health <= backgrounds.Count)
        {
            if (currentBackground != null)
            {
                currentBackground.SetActive(false);
            }

            audioManager.PlayPlayerHit();
            health = health + 3;
            currentBackground = backgrounds[health];
            currentBackground.SetActive(true);
        }
    }

}
