using UnityEngine;
using UnityEngine.UI;

public class DutchCourageMeter : MonoBehaviour
{
    public float maxCourage = 35f;
    public float minCourage = 0f;
    public float startingCourage = 21f;
    public float currentCourage;
    public Image dutchCouragefillAmount;

    public PlayerMovement refillPosition;

    public Animator player;

    private void Start()
    {
        currentCourage = startingCourage;
        
    }
    private void Update()
    {
        //float refill = dutchCouragefillAmount.fillAmount;
        dutchCouragefillAmount.fillAmount = currentCourage / 35f;
        player.SetFloat("DutchCourage", currentCourage);
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
            currentCourage += Time.deltaTime * 13f;
        }

        else if (currentCourage <= 35f)
        {
            currentCourage += Time.deltaTime * 15f;
        }
    }

    public void MeterDepletion()
    {
        currentCourage -= Time.deltaTime;
    }
}
