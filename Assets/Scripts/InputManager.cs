using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float swipeThreshold = 0.5f;

    private Vector3 tapStartPosition = Vector3.zero;
    private Vector3 tapEndPosition = Vector3.zero;

    //'Delegate and event' pairs
    public delegate void OnTapHandler();
    public static event OnTapHandler OnTap;

    public delegate void OnSwipeHandler(string direction);
    public static event OnSwipeHandler OnSwipe;

    //this will run when a tap is detected - callbackConext gives us information about the tap's state
    public void Tap(InputAction.CallbackContext tap)
    {
        if (tap.started == true)
        {
            // Debug.Log("tap");
            tapStartPosition = GetTapPosition();
        }
        else if (tap.canceled == true)
        {

            // Debug.Log("tapdone");
            tapEndPosition = GetTapPosition();
            CheckForSwipe();
            OnTap?.Invoke();
        }
    }

    private Vector3 GetTapPosition()
    {
        Vector3 pointerPosition = Pointer.current.position.ReadValue();

        return pointerPosition;
    }

    private void CheckForSwipe()
    {
        //Convert the pointer positions into world positions
        Vector3 tapStartWorldPosition = tapStartPosition;
        tapStartWorldPosition.z = 1f;
        tapStartWorldPosition = Camera.main.ScreenToWorldPoint(tapStartWorldPosition);

        Vector3 tapEndWorldPosition = tapEndPosition;
        tapEndWorldPosition.z = 1f;
        tapEndWorldPosition = Camera.main.ScreenToWorldPoint(tapEndWorldPosition);

        //Calculate the difference between the start and end points
        float distanceSwiped = Vector3.Distance(tapStartWorldPosition, tapEndWorldPosition);

        if(distanceSwiped >= swipeThreshold)
        {
            string direction = "";

            //Record how much the tap has move between the start and end 
            float horizontalSwipe = tapEndPosition.x - tapStartPosition.x;
            float verticalSwipe = tapEndPosition.y - tapStartPosition.y;

            //Convert the horizontal and vertical swipe so they are always positive
            //Check if the horizontal movement is greater than the vertical movement
            if (Mathf.Abs(horizontalSwipe) > Mathf.Abs(verticalSwipe))
            {
                if (horizontalSwipe > 0)
                {
                    direction = "Right";
                }
                else if (horizontalSwipe < 0)
                {
                    direction = "Left";
                }
            }
            //Otherwise if vertical movement is greater
            else
            {
                if (verticalSwipe > 0)
                {
                    direction = "Up";
                }
                else
                {
                    direction = "Down";
                }
            }
           // Debug.Log(direction);
            OnSwipe?.Invoke(direction);
        }
    }
}
