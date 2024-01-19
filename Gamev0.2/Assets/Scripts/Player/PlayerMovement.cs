using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveStime;
    public float GravityPower;
    public float JumpPower;
    public float WalkSpeed;
    public float RunSpeed;


    private CharacterController cc;
    private Vector3 CurrentMoveVelocity;
    private Vector3 MoveDampVelocity;

    private float gravity = 12f;
    private float verticalSpeed;
    private float jumpForce = 5f; 
    private bool isJumping = false;






    private Vector3 CurrentForceVelocity;
    void Start()
    {
        cc = GetComponent<CharacterController>();
       
    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleGravity();
        if (cc.isGrounded)
        {
            isJumping = false;
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        Vector3 PlayerInput = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")
        };
        if (PlayerInput.magnitude > 1f)
        {
            PlayerInput.Normalize();
        }
        Vector3 MoveVector = transform.TransformDirection(PlayerInput);

        float CurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : WalkSpeed;
        CurrentMoveVelocity = Vector3.SmoothDamp(
            CurrentMoveVelocity,
            MoveVector*CurrentSpeed,
            ref MoveDampVelocity,
            MoveStime);

        cc.Move(CurrentMoveVelocity * Time.deltaTime);
    }
    private void HandleGravity()
    {
        if (!cc.isGrounded)
        {
            // Apply gravity to the vertical speed
            verticalSpeed -= gravity * Time.deltaTime;
        }
        else
        {
            // Reset vertical speed when the player is grounded
            verticalSpeed = -0.5f;
        }

        // Apply the vertical speed to move the player vertically
        cc.Move(new Vector3(0, verticalSpeed, 0) * Time.deltaTime);
    }
    private void Jump()
    {
        if (!isJumping)
        {
            // Apply jump force to the vertical speed
            verticalSpeed = jumpForce;
            isJumping = true;
        }
    }


}
