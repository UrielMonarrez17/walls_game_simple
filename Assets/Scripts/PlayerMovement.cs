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
        
        if (controller == null)
            controller = GetComponent<Controller>();
    }

    private void Update()
    {
      
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}