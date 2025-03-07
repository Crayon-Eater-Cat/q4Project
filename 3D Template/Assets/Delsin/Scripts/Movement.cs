using UnityEngine;

/*
    This script provides jumping and movement in Unity 3D - Gatsby
*/

public class Player1 : MonoBehaviour
{
    // Keybinds
    public KeyCode jump, forward, backward, left, right, sprint;
    
    // Camera Rotation
    public float mouseSensitivity = 2f;
    private float verticalRotation = 0f;
    private Transform cameraTransform;
    
    // Ground Movement
    private Rigidbody rb;
    public float MoveSpeed;
    public float StartSpeed = 50f;
    public float DashTimerBase;
    private float DashTimer;
    public float DashCDBase;
    private float DashCD;
    private bool DashUse = true;
    private bool startDash = false;
    private float SprintSpeed;
    private float moveHorizontal;
    private float moveForward;
    
    // Jumping
    public float jumpForce = 10f;
    public float fallMultiplier = 2.5f; // Multiplies gravity when falling down
    public float ascendMultiplier = 2f; // Multiplies gravity for ascending to peak of jump
    public float dbJumpLimits;
    private bool isGrounded = true;
    public LayerMask groundLayer;
    private float dbJump;
    private float groundCheckTimer = 0f;
    private float groundCheckDelay = 0.3f;
    private float playerHeight;
    private float raycastDistance;

    void Start()
    {
        DashTimer = DashTimerBase;
        DashCD = DashCDBase;

        SprintSpeed = (MoveSpeed * 2);
        dbJump = dbJumpLimits;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        cameraTransform = Camera.main.transform;

        // Set the raycast to be slightly beneath the player's feet
        playerHeight = GetComponent<CapsuleCollider>().height * transform.localScale.y;
        raycastDistance = (playerHeight / 2) + 0.2f;

        // Hides the mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveForward = Input.GetAxisRaw("Vertical");

        RotateCamera();

        if (Input.GetKey(sprint) && DashUse)
        {
            Debug.Log("SPEED");
            MoveSpeed = 500f;
            startDash = true;
            DashCD = DashCDBase;
        }
        if (Input.GetKeyUp(sprint))
        {
            Debug.Log("No speed");
            MoveSpeed = StartSpeed;
        }
        if (startDash)
        {
            DashTimer -= Time.deltaTime;
            if (DashTimer <= 0)
            {
                DashTimer = 0;
                MoveSpeed = 50f;
                DashUse = false;
                DashCD -= Time.deltaTime;
            }
        }
        if (DashCD <= 0)
        {
            DashTimer = DashTimerBase;
            DashUse = true;
        }
        if (Input.GetKeyDown(jump))
        {
            dbJumpLimit();
        }

        // Checking when we're on the ground and keeping track of our ground check delay
        if (!isGrounded && groundCheckTimer <= 0f)
        {
            Vector3 rayOrigin = transform.position + Vector3.up * 0.1f;
            isGrounded = Physics.Raycast(rayOrigin, Vector3.down, raycastDistance, groundLayer);
        }
        else
        {
            groundCheckTimer -= Time.deltaTime;
        }

    }

    void FixedUpdate()
    {
        MovePlayer();
        ApplyJumpPhysics();
    }

    void MovePlayer()
    {

        Vector3 movement = (transform.right * moveHorizontal + transform.forward * moveForward).normalized;
        Vector3 targetVelocity = movement * MoveSpeed;

        // Apply movement to the Rigidbody
        Vector3 velocity = rb.linearVelocity;
        velocity.x = targetVelocity.x;
        velocity.z = targetVelocity.z;
        rb.linearVelocity = velocity;
      
        // If we aren't moving and are on the ground, stop velocity so we don't slide
        //if (isGrounded && moveHorizontal == 0 && moveForward == 0)
        //{
        //    rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
        //}
    }

    void RotateCamera()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, horizontalRotation, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    void dbJumpLimit()
    {
        if (isGrounded) 
        {
            dbJump = dbJumpLimits;
        }
        if (dbJump == 0)
        {
            //Jump();
            //isGrounded = false;
        }
        else if (dbJump >= 1)
        {
            Jump();
        }

    }

    void Jump()
    {
        if (dbJump >= 1)
        {
            dbJump--;
        }
        if (dbJump <= 0)
        {
            dbJump = 0;
        }
        isGrounded = false;
        groundCheckTimer = groundCheckDelay;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z); // Initial burst for the jump
    }

    void ApplyJumpPhysics()
    {
        if (rb.linearVelocity.y < 0)
        {
            // Falling: Apply fall multiplier to make descent faster
            rb.linearVelocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.fixedDeltaTime;
        } // Rising
        else if (rb.linearVelocity.y > 0)
        {
            // Rising: Change multiplier to make player reach peak of jump faster
            rb.linearVelocity += Vector3.up * Physics.gravity.y * ascendMultiplier * Time.fixedDeltaTime;
        }
    }
}