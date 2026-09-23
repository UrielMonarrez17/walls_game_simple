using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    public Controller controller;

    [Header("Settings")]
    public float runSpeed = 40f;

    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;

    private void Start()
    {
        // Automatically fetch the Controller script if not assigned manually
        if (controller == null)
            controller = GetComponent<Controller>();
    }

    private void Update()
    {
        // Read Left/Right Arrow or A/D key inputs (-1 to 1)
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // Check for Jump input (Spacebar by default)
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        // Check for Crouch input (S or Down Arrow by default)
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            crouch = true;
        }
        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        // Pass the collected inputs to the Controller script
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}