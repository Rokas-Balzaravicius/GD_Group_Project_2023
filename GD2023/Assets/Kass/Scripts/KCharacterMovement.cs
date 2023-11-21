using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KCharacterMovement : MonoBehaviour
{
    public float forward, back, strafe, sensitivity, force;
    Rigidbody rb;
    Animator animator;
    bool grounded;
    float checkDistance = 1;
    float checkRadius = 0.5f;
    private float turningSpeed = 130;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            print("Ouch!!! I just hit a " + collision.gameObject.name);
        }
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
        if (rb.velocity.y < -1)
        {
            animator.SetBool("falling", true);
            animator.SetBool("jumpUp", false);
            animator.SetBool("walkJump", false);
        }


        //Sprint
        if (Input.GetKey(KeyCode.LeftControl))
        {
            forward = 10;
            back = 6;
            strafe = 8;
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("isRunning", true);
            }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("isRunningBack", true);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            forward = 5;
            strafe = 5;
            animator.SetBool("isRunning", false);
            animator.SetBool("isRunningBack", false);
        }


        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
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

            if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
            {
                rb.AddForce(Vector3.up * force);
                grounded = false;
                animator.SetBool("walkJump", true);
                animator.SetBool("onGround", false);
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }

        //Walk Back
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * back;
            animator.SetBool("backWalk", true);
            if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
            {
                rb.AddForce(Vector3.up * force);
                grounded = false;
                animator.SetBool("walkJump", true);
                animator.SetBool("onGround", false);
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("backWalk", false);
            animator.SetBool("isRunningBack", false);
        }

        //Walk Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turningSpeed * Time.deltaTime);
            transform.position += transform.forward * Time.deltaTime * strafe;
            animator.SetBool("isWalking", true);

            if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
            {
                rb.AddForce(Vector3.up * force);
                grounded = false;
                animator.SetBool("walkJump", true);
                animator.SetBool("onGround", false);
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }

        //Walk Right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);
            transform.position += transform.forward * Time.deltaTime * strafe;
            animator.SetBool("isWalking", true);

            if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
            {
                rb.AddForce(Vector3.up * force);
                grounded = false;
                animator.SetBool("walkJump", true);
                animator.SetBool("onGround", false);
            }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            // Harvest Check
            Collider[] allPossibleInteractives = Physics.OverlapSphere(transform.position + checkDistance * transform.forward, checkRadius);
            print("Found " + allPossibleInteractives.Length.ToString());
            foreach (Collider c in allPossibleInteractives)
            {
                KRockScript myRock = c.GetComponent<KRockScript>();
                if (myRock != null)
                {
                    print("I found a rock");
                    myRock.ImHavestingYou(this);

                }

            }
            animator.SetBool("pickUp", true);
        }
        else
        {
            animator.SetBool("pickUp", false);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            animator.SetBool("Shield", true);
            print("Shield");
        }
    }
}
