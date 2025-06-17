using UnityEngine;

public class DutchCourageMeter : MonoBehaviour
{
    public float maxCourage = 35f;
    public float minCourage = 0f;
    public float startingCourage = 30f;
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
        currentCourage = Mathf.Clamp(currentCourage, minCourage, maxCourage);
    }
    public void RefillCourage()
    {
        if (currentCourage <= 10f)
        {
            currentCourage += Time.deltaTime * 4f;
        }

        else if (currentCourage <= 20f)
        {
            currentCourage += Time.deltaTime * 7f;
        }

        else if (currentCourage <= 30f)
        {
            currentCourage += Time.deltaTime * 11f;
        }

        else if (currentCourage <= 35f)
        {
            currentCourage += Time.deltaTime * 13f;
        }
    }

    public void MeterDepletion()
    {
        currentCourage -= Time.deltaTime;
    }
}
