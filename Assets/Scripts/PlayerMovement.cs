using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    const int maxLanes = 3;

    private void Start()
    {
  
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
                
                break;
            case "Left":
                //Move player one lane to the left, unless already at the leftmost lane
                break;
            case "Down":
                //Move player down to the Dutch courage refill minigame, unless already there
                break;
            case "Up":
                //Move player up to the ship bow, unless already there
                break;
        }
    }
}
