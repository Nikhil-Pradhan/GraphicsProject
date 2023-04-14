using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    // [Header("Slope Handling")]
    // public float maxSlopeAngle;
    // private RaycastHit slopeHit;
    // private bool exitingSlope;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }

    private void Update() {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        if(grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate() {
        MovePlayer();
    }

    private void MyInput() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && readyToJump && grounded) {
            readyToJump = false;
            Jump();
            Invoke(nameof(resetJump), jumpCooldown);
        }
    }

    private void MovePlayer()  {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // if (onSlope() && !exitingSlope) {
        //     rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);
        //     if (rb.velocity.y > 0)
        //         rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        // }
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        // rb.useGravity = !onSlope();
    }

    private void SpeedControl() {
        // if (onSlope()) {
        //     if(rb.velocity.magnitude > moveSpeed && !exitingSlope)
        //         rb.velocity = rb.velocity.normalized * moveSpeed;
        // }
        // else {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            if(flatVel.magnitude > moveSpeed) {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        // }
    }

    private void Jump(){
        // exitingSlope = true;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void resetJump() {
        readyToJump = true;
        // exitingSlope = false;
    }

    // private bool onSlope() {
    //     if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
    //         return Vector3.Angle(Vector3.up, slopeHit.normal) < maxSlopeAngle;
    //     return false;
    // }

    // private Vector3 GetSlopeMoveDirection() {
    //     return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    // }
}