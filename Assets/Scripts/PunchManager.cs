using System.Collections;
using UnityEditor;
using UnityEngine;

public class PunchManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public HealthManager healthManager;
    public DutchCourageMeter dutchCourageMeter;
    public ShipHealth shipHealth;
    public AudioManager audioManager;

    public Animator player;
    public Animator splash;
    public Animator hit;
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
            StartCoroutine(LowCourageHit());
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
        audioManager.PlayPunch();
        audioManager.PlayHighYaar();
        scoreManager.AddScore1();
        yield return new WaitForSeconds(1.5f);
        if (shipHealth == null) yield break;
        shipHealth.ShipHit();
        shipHealth.StartCoroutine(shipHealth.DestroyShip());
        scoreManager.AddScore2();
   

    }
    private IEnumerator MidCourageHit(ShipHealth shipHealth)
    {
        player.SetTrigger("punchnormal");
        audioManager.PlayPunch();
        audioManager.PlayMidYaar();
        scoreManager.AddScore1();
        yield return new WaitForSeconds(1.5f);
        if (shipHealth == null) yield break;
        shipHealth.ShipHit();
        shipHealth.shipHealth--;
        if (shipHealth.shipHealth <= 0)
        {
            shipHealth.ShipHit();
            shipHealth.StartCoroutine(shipHealth.DestroyShip());
            scoreManager.AddScore2();
        }
    }
    private IEnumerator LowCourageHit()
    {
        player.SetTrigger("punchlow");
        audioManager.PlayPunch();
        audioManager.PlayLowYaar();
        scoreManager.AddScore1();
        yield return new WaitForSeconds(1.2f);
        splash.SetTrigger("splash");
        audioManager.PlaySplash();
        //play animation cannonball falling in water
    }
    private void TooMuchCourageHit()
    {
        player.SetTrigger("punchdrunk");
        audioManager.PlayDrunkYaar();
        hit.SetTrigger("shipHit");
        if (scoreManager.score > 50)
        {
            healthManager.TakeThreeDamage();
        }

        else healthManager.TakeTwoDamage();
    }
}
