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
    public ScoreManager scoreManager;

    private void Start()
    {
        currentCourage = startingCourage;
        
    }
    private void Update()
    {
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
            currentCourage += Time.deltaTime * 8f;
        }

        else if (currentCourage <= 20f)
        {
            currentCourage += Time.deltaTime * 10f;
        }

        else if (currentCourage <= 29f)
        {
            currentCourage += Time.deltaTime * 19f;
        }

        else if (currentCourage <= 35f)
        {
            currentCourage += Time.deltaTime * 23f;
        }
    }

    public void MeterDepletion()
    {
        if (scoreManager.score > 50)
        {
            currentCourage -= Time.deltaTime * 2.5f;
        }

        else currentCourage -= Time.deltaTime;
    }
}
