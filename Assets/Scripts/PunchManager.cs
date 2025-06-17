using System.Collections;
using UnityEngine;

public class PunchManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public HealthManager healthManager;
    public DutchCourageMeter dutchCourageMeter;
   // public ShipHealth shipHealth;
    private void Start()
    {
       /* scoreManager = GetComponent<ScoreManager>();
        healthManager = GetComponent<HealthManager>();*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        var gravity = collision.gameObject.GetComponent<Rigidbody2D>();
        gravity.gravityScale = -4;

        if (dutchCourageMeter.currentCourage <= 10f)
        {
            LowCourageHit();
            Debug.Log("lowhit");
        }

        else if (dutchCourageMeter.currentCourage <= 20f)
        {
            StartCoroutine(MidCourageHit());
            Debug.Log("midhit");
        }

        else if (dutchCourageMeter.currentCourage <= 30f)
        {
            StartCoroutine(HighCourageHit());
            Debug.Log("highhit");
        }

        else if (dutchCourageMeter.currentCourage <= 35f)
        {
            TooMuchCourageHit();
            Debug.Log("toomuchhit");
        }

    }
    private IEnumerator HighCourageHit(//ShipHealth shipHealth)
    {
        scoreManager.AddScore1();
        //play animation ship getting hit
        yield return new WaitForSeconds(2f);
       // shipHealth.shipHealth -= 3;
        shipHealth.DestroyShip();
        scoreManager.AddScore2();
   

    }
    private IEnumerator MidCourageHit(//ShipHealth shipHealth)
    {
        scoreManager.AddScore1();
        //play animation ship getting hit
        yield return new WaitForSeconds(2f);
        shipHealth.shipHealth--;
        if (shipHealth.shipHealth <= 0)
        {
            //play animation of ship getting destroyed
            //delete ship
            shipHealth.DestroyShip();
            scoreManager.AddScore2();
        }
    }
    private void LowCourageHit()
    {
        scoreManager.AddScore1();
        //play animation cannonball falling in water
    }
    private void TooMuchCourageHit()
    {
        healthManager.TakeTwoDamage();
        //play animation player missing canonball 
    }
}
