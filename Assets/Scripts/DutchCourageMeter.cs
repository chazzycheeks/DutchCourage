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
    public AudioManager audioManager;

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

        //currentCourange += Time.deltaTime * depletionFactor * refillFactor;
        currentCourage = Mathf.Clamp(currentCourage, minCourage, maxCourage);

        

    }
    public void RefillCourage()
    {
        float increaseFactor = 1f;
        if (scoreManager.score > 100)
        {
            if (currentCourage <= 10f)
            {
                increaseFactor = 24f;
            }

            else if (currentCourage <= 20f)
            {
                increaseFactor = 30f;
            }

            else if (currentCourage <= 29f)
            {
                increaseFactor = 60f;
            }

            else if (currentCourage <= 35f)
            {
                increaseFactor = 75f;
            }
        }

        else if (scoreManager.score > 50)
        {
            if (currentCourage <= 10f)
            {
                increaseFactor = 17.6f;
            }

            else if (currentCourage <= 20f)
            {
                increaseFactor = 20f;
            }

            else if (currentCourage <= 29f)
            {
                increaseFactor = 40f;
            }

            else if (currentCourage <= 35f)
            {
                increaseFactor = 50f;
            }
        }

        else
        {
            if (currentCourage <= 10f)
            {
                increaseFactor = 8f;
            }

            else if (currentCourage <= 20f)
            {
                increaseFactor = 10f;
            }

            else if (currentCourage <= 29f)
            {
                increaseFactor = 20f;
            }

            else if (currentCourage <= 35f)
            {
                increaseFactor = 25f;
            }
        }

        currentCourage += Time.deltaTime * increaseFactor;
    }

    public void MeterDepletion()
    {
        float depletionFactor = 1f;
        if (scoreManager.score > 100)
        {
            depletionFactor = 3f;
        }
        else if (scoreManager.score > 50)
        {
            depletionFactor = 2.2f;
        }

        /*if (currentCourage > 10f)
        {
            audioManager.PlayLowCourageAlert();
        }*/

        currentCourage -= Time.deltaTime * depletionFactor;
    }
}
