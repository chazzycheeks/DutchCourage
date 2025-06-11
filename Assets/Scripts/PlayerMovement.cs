using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    private int currentLane;
    public List<Transform> lanes = new();
    public Transform refillMeterPosition;
    private bool refilling;
    //Transform which is our down position

    //Array of transforms which are used for the lanes (all lanes)

    //Int which keeps track of which lane we are in (current lane)

    private void Start()
    {
        currentLane = 1;
    }
    private void OnEnable()
    {
        InputManager.OnSwipe += ProcessSwipe;
    }

    private void OnDisable()
    {
        InputManager.OnSwipe -= ProcessSwipe;
    }
    private void ProcessSwipe(string direction)
    {
        switch (direction)
        {
            case "Right":
                if (refilling) return;
               
                currentLane++;
                if (currentLane > 2)
                {
                    currentLane--;
                }
                player.transform.position = lanes[currentLane].position;
                break;

            case "Left":
                if (refilling) return;
                currentLane--;
                if (currentLane < 0)
                {
                    currentLane++;
                }
                player.transform.position = lanes[currentLane].position;
                break;

            case "Down":
                player.transform.position = refillMeterPosition.position;
                refilling = true;
                break;

            case "Up":
                refilling = false;
                player.transform.position = lanes[currentLane].position;
                break;
        }
    }
}
