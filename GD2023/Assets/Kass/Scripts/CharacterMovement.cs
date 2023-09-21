using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", false);
    }

    // Update is called once per frame
    void Update()
    {

        float walk = 5, run = 5, strafe = 5, jump = 15, turningSpeed = 150, force = 10;

        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(transform.up, -turningSpeed * Time.deltaTime);
        }
        else if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(transform.up, turningSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            run = 10;
            strafe = 8;
        }

//      if (Input.GetKey(KeyCode.Space))
//       {
//           Rigidbody.AddForce(Vector3.up * force);
//       }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * run;
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isWalking", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * walk;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * strafe;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * strafe;
        }
    }
}
