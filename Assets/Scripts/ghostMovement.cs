using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    // public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    public GameObject player;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update() {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        moveDirection = player.transform.position - transform.position;
        moveDirection.y = 0;
        if (moveDirection.magnitude < 12)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        SpeedControl();

        if(grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void SpeedControl() { 
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed) {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Player") {
            collision.gameObject.GetComponent<PlayerMovement>().multiplyxhalf();
            this.gameObject.SetActive(false);
        }
        else if (collision.collider.tag == "Floor")
            this.gameObject.SetActive(false);
    }
}
