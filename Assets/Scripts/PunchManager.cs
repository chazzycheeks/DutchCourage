using System.Collections;
using UnityEngine;

public class PunchManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public HealthManager healthManager;
    public DutchCourageMeter dutchCourageMeter;

    public Animator player;
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
        ShipHealth shipHealth = collision.gameObject.GetComponent<Projectile>().shipHealth;

        if (dutchCourageMeter.currentCourage <= 10f)
        {
            LowCourageHit();
            Debug.Log("lowhit");
        }

        else if (dutchCourageMeter.currentCourage <= 20f)
        {
            StartCoroutine(MidCourageHit(shipHealth));
            Debug.Log("midhit");
        }

        else if (dutchCourageMeter.currentCourage <= 30f)
        {
            StartCoroutine(HighCourageHit(shipHealth));
            Debug.Log("highhit");
        }

        else if (dutchCourageMeter.currentCourage <= 35f)
        {
            TooMuchCourageHit();
            Debug.Log("toomuchhit");
        }

    }
    private IEnumerator HighCourageHit(ShipHealth shipHealth)
    {
        player.SetTrigger("punchcourageous");
        scoreManager.AddScore1();
        //play animation ship getting hit
        yield return new WaitForSeconds(2f);
       // shipHealth.shipHealth -= 3;
        shipHealth.DestroyShip();
        scoreManager.AddScore2();
   

    }
    private IEnumerator MidCourageHit(ShipHealth shipHealth)
    {
        player.SetTrigger("punchnormal");
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
        player.SetTrigger("punchlow");
        scoreManager.AddScore1();
        //play animation cannonball falling in water
    }
    private void TooMuchCourageHit()
    {
        player.SetTrigger("punchdrunk");
        healthManager.TakeTwoDamage();
    }
}
