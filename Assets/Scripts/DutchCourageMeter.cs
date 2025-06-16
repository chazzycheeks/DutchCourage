using UnityEngine;

public class DutchCourageMeter : MonoBehaviour
{
    public float maxCourage = 40f;
    public float minCourage = 0f;
    public float startingCourage = 20f;
    public float currentCourage;

    public PlayerMovement refillPosition;

    private void Start()
    {
        currentCourage = startingCourage;
     
    }
    private void Update()
    {
        MeterDepletion();

        if (refillPosition.refilling == true)
        {
            RefillCourage();
        }
    }
    public void RefillCourage()
    {
        if (currentCourage <= 10f)
        {
            currentCourage += Time.deltaTime;
        }

        if (currentCourage <= 20f)
        {
            currentCourage += Time.deltaTime * 1.5f;
        }

        if (currentCourage <= 30f)
        {
            currentCourage += Time.deltaTime * 2f;
        }

        if (currentCourage <= 40f)
        {
            currentCourage += Time.deltaTime * 4f;
        }
    }

    public void MeterDepletion()
    {
        currentCourage -= Time.deltaTime;
    }
}
