using UnityEngine;

public class DutchCourageMeter : MonoBehaviour
{
    public int maxCourage = 10;
    public int minCourage = 0;
    public int startingCourage = 5;
    public int currentCourage;

    PlayerMovement refillPosition;

    private void Start()
    {
        refillPosition = GetComponent<PlayerMovement>();
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

    }

    public void MeterDepletion()
    {

    }
}
