using System.Collections;
using UnityEngine;

public class PunchManager : MonoBehaviour
{
    ScoreManager scoreManager;
    HealthManager healthManager;
    public DutchCourageMeter dutchCourageMeter;
    private void Start()
    {
        scoreManager = GetComponent<ScoreManager>();
        healthManager = GetComponent<HealthManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        var gravity = collision.gameObject.GetComponent<Rigidbody2D>();
        gravity.gravityScale = -4;

        if (dutchCourageMeter.currentCourage <= 10f)
        {
            LowCourageHit();
        }

        if (dutchCourageMeter.currentCourage <= 20f)
        {
            MidCourageHit();
        }

        if (dutchCourageMeter.currentCourage <= 30f)
        {
            HighCourageHit();
        }

        if (dutchCourageMeter.currentCourage <= 40f)
        {
            TooMuchCourageHit();
        }
        //depending on the dutch courage meter level, begin one of the methods below



    }
    private IEnumerator HighCourageHit()
    {
        yield return new WaitForSeconds(2f);
        //play animation ship getting destroyed
        //delete ship
        scoreManager.AddScore2();
    }
    private IEnumerator MidCourageHit()
    {
        yield return new WaitForSeconds(2f);
        scoreManager.AddScore1();
    }
    private IEnumerator LowCourageHit()
    {
        yield return new WaitForSeconds(2f);
        //canonball comes back down and hits ship
        healthManager.TakeOneDamage();
    }
    private IEnumerator TooMuchCourageHit()
    {
        yield return new WaitForSeconds(2f);
        //play animation player missing canonball 
        healthManager.TakeThreeDamage();
    }
}
