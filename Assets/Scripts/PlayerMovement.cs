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
                //Move player one lane to the right, unless already at the rightmost lane
                currentLane++;
                if (currentLane > 2)
                {
                    currentLane--;
                }
                player.transform.position = lanes[currentLane].position;
                break;
            case "Left":
                currentLane--;
                if (currentLane < 0)
                {
                    currentLane++;
                }
                player.transform.position = lanes[currentLane].position;
                //Move player one lane to the left, unless already at the leftmost lane
                break;
            case "Down":
                player.transform.position = refillMeterPosition.position;
                refilling = true;
                if (refilling == true)
                {
                    //disbale left and right movement
                }
                //Move player down to the Dutch courage refill minigame, unless already there
                //Set the player's position to the down position
                break;
            case "Up":
                refilling = false;
                player.transform.position = lanes[currentLane].position;
                //Move player up to the ship bow, unless already there
                //Set the player's position as the current lane
                break;
        }
    }

    //Move right:
    //Increase the current lane by 1
    //Use Mathf.Clamp to keep the current lane between 0 and the number of lanes - if that doesn't work, use the following logic:
    //If current lane is less than zero, current lane should equal zero
    //If current lane is equal to or greater than the length of the lane array, then the current lane should be equal to the length of the array - 1
    //Use the current lane to pick the correct transform from our array
    //Move the player towards that transform

    //Move left:
    //Same as the above, but we decrease the current lane by 1
}
