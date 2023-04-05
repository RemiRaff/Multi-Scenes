using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPPAController : MonoBehaviour
{
    // Based on: https://www.youtube.com/watch?v=lYJtTYveYg0
    // References
    [SerializeField] Transform cameraTransform;
    [SerializeField] CharacterController characterController;

    // Players settings
    [SerializeField] float cameraSensitivity = 10f;
    [SerializeField] float walkSpeed = 8f;
    [SerializeField] float moveInputDeadZone = 10f;

    // Touch detection
    private int leftFingerID; // movement
    private int rightFingerID; // look
    private float halfScreenWidth; // frontier between movement and look

    // Camera Controller
    private Vector2 lookInput;
    private float cameraPitch;

    // Player movement
    private Vector2 moveTouchStartPosition;
    private Vector2 moveInput;


    // Start is called before the first frame update
    void Start()
    {
        // ID -1 at settup, it is not being tracked
        leftFingerID = -1;
        rightFingerID = -1;

        // setup just one time
        halfScreenWidth = Screen.width / 2;

        // calculate the movement input dead zone
        moveInputDeadZone = Mathf.Pow(Screen.height / moveInputDeadZone, 2);
    }

    // Update is called once per frame
    private void Update()
    {
        // Handles input
        GetTouchInput();

        // Only look around if the right finger is being tracked
        if (rightFingerID != -1)
        {
            LookAround();
        }

        // Only move if the left finger is being tracked
        if (leftFingerID != -1)
        {
            Move();
        }
    }

    private void GetTouchInput()
    {
        // Iterate through all the detected touches
        for (int i=0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);

            // Check each touch's phase
            switch (t.phase)
            {
                case TouchPhase.Began:
                    // change the ID if necessary depending on the side
                    if (t.position.x < halfScreenWidth && leftFingerID == -1) // good side for left finger
                    {
                        // Start tracking left finger if it was not previously being tracked
                        leftFingerID = t.fingerId;

                        // Set the start position of the movement control finger
                        moveTouchStartPosition = t.position;
                    }
                    else if (halfScreenWidth < t.position.x && rightFingerID == -1) // good side for right finger
                    {
                        // Start tracking right finger if it was not previously being tracked
                        rightFingerID = t.fingerId;
                        // Debug.Log("Tracking right figer...");
                    }
                    break;
                case TouchPhase.Ended: // same as Canceled
                case TouchPhase.Canceled:
                    // When we release a finger
                    if (t.fingerId == leftFingerID)
                    {
                        // Stop tracking the left finger
                        leftFingerID = -1;
                        // Debug.Log("Stopped tracking the left finger");
                    }
                    else if (t.fingerId == rightFingerID)
                    {
                        // Stop tracking the right finger
                        rightFingerID = -1;
                        // Debug.Log("Stopped tracking the right finger");
                    }
                    break;
                case TouchPhase.Moved:
                    // Get Input for looking around
                    if (t.fingerId == rightFingerID)
                    {
                        lookInput = t.deltaPosition * cameraSensitivity * Time.deltaTime;
                    }
                    else if (t.fingerId == leftFingerID)
                    {
                        // calculating the position delta from start position
                        moveInput = t.position - moveTouchStartPosition;
                    }
                    break;
                case TouchPhase.Stationary:
                    // Set the lookInput to 0 if the finger is still 
                    if (t.fingerId == rightFingerID)
                    {
                        lookInput = Vector2.zero;
                    }
                    break;
            } // end swith Touch Phase
        } // end touches iteration
    } // end GetTouchInput

    private void LookAround() // right finger
    {
        // vertical rotation (pitch)
        cameraPitch = Mathf.Clamp(cameraPitch - lookInput.y, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);

        // horizontal rotation (yaw)
        transform.Rotate(transform.up, lookInput.x);
    }

    private void Move()
    {
        // Don't move if the touch delta is shorter then the designed dead zone
        if (moveInput.sqrMagnitude <= moveInputDeadZone) return;

        // Multiply the normalized direction by the speed
        Vector2 movementDirection = moveInput.normalized * walkSpeed * Time.deltaTime;
        // Move relatively to the local transform's direction
        characterController.Move(transform.right * movementDirection.x + transform.forward * movementDirection.y);
    }
}
