using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{
    public float forward = 5, back = 5, strafe = 5, sensitivity = 150, force = 10;
    Rigidbody rb;
    Animator animator;
    bool grounded;

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            animator.SetBool("onGround", true);
            animator.SetBool("falling", false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        animator.SetBool("isWalking", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0)
        {
            animator.SetBool("falling", true);
        }


        //Camera Movement
        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(transform.up, -sensitivity * Time.deltaTime);
        }
        else if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(transform.up, sensitivity * Time.deltaTime);
        }


        //Sprint
        if (Input.GetKey(KeyCode.LeftControl))
        {
            forward = 10;
            back = 6;
            strafe = 8;
            animator.SetBool("isRunning", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            forward = 5;
            strafe = 5;
            animator.SetBool("isRunning", false);
        }


        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rb.AddForce(Vector3.up * force);
            grounded = false;
            animator.SetBool("jumpUp", true);
            animator.SetBool("onGround", false);
        }


        //Walk Forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * forward;
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isWalking", false);
        }

        //Walk Back
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * back;
            animator.SetBool("backWalk", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("backWalk", false);
        }

        //Walk Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * strafe;
        }

        //Walk Right
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * strafe;
        }
    }
}
