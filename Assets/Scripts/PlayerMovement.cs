using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Can be edited inside unity but can't be used by other scripts
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] AudioSource jumpSound;

    private Rigidbody rb;

    // public can be used by other scripts.
    //public float movementSpeed;
    //public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rb.velocity = new Vector3(rb.velocity.x , jumpMovement, rb.velocity.z);
        //}

        //if (Input.GetKey(KeyCode.W))
        //{
        //    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, forwardMovement);
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -backwardMovement);
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    rb.velocity = new Vector3(-leftMovement, rb.velocity.y, rb.velocity.z);
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    rb.velocity = new Vector3(rightMovement, rb.velocity.y, rb.velocity.z);
        //}
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
