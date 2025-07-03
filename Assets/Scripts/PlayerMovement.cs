using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    private int currentLane;
    public List<Transform> lanes = new();
    public Transform refillMeterPosition;
    public bool refilling;
    [SerializeField] private bool canMove;
    private bool hasAwoken = false;
    public PauseMenu PauseMenu;

    public Animator playerAnim;
    public Animator closeUp;
    public Animator cameraAnim;
    
    public AudioManager audioManager;

    private void Start()
    {
        currentLane = 1;
        canMove = false;
    }
    private void Update()
    {
        playerAnim.SetBool("isRefilling", refilling);
        closeUp.SetBool("isRefilling", refilling);
        cameraAnim.SetBool("isRefilling", refilling);

        if (!hasAwoken) return;
        if (PauseMenu.isPaused == true)
        {
            canMove = false;
        }
        else canMove = true;
    }
    private void OnEnable()
    {
        InputManager.OnSwipe += ProcessSwipe;
        
    }

    private void OnDisable()
    {
        InputManager.OnSwipe -= ProcessSwipe;
    }

    public void ToggleMovement() => hasAwoken = true;
    private void ProcessSwipe(string direction)
    {
        if (!canMove) { return; }
        switch (direction)
        {
            case "Right":
                if (refilling) return;
                audioManager.PlayMove();
                currentLane++;
                if (currentLane > 2)
                {
                    currentLane--;
                }
                player.transform.position = lanes[currentLane].position;
                break;

            case "Left":
                if (refilling) return;
                audioManager.PlayMove();
                currentLane--;
                if (currentLane < 0)
                {
                    currentLane++;     
                }
                player.transform.position = lanes[currentLane].position;
                break;

            case "Down":
                player.transform.position = refillMeterPosition.position;
                audioManager.PlayMove();
                audioManager.PlaySwig();
                audioManager.PlayGlug();
                refilling = true;
                break;

            case "Up":
                refilling = false;
                player.transform.position = lanes[currentLane].position;
                audioManager.PlayMove();
                break;
        }
    }
}
