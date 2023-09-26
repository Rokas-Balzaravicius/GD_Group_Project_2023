using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{

    float currentSpeed = 2;
    float walkingSpeed = 2;
    float runningSpeed = 4;
    private float turningSpeed = 130;

    Animator edAnimator;

    // Start is called before the first frame update
    void Start()
    {
        edAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runningSpeed;
            edAnimator.SetBool("isRunning", true);
        }
        else
        {
            currentSpeed = walkingSpeed;
            edAnimator.SetBool("isRunning", false);
        }

        edAnimator.SetBool("isWalking", false);

        if (Input.GetKey(KeyCode.W))
        {   ///   s            =         u                      *       t
            transform.position += currentSpeed * transform.forward * Time.deltaTime;
            edAnimator.SetBool("isWalking", true);
        }
    


        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turningSpeed * Time.deltaTime);
            transform.position += currentSpeed * transform.forward * Time.deltaTime;

            edAnimator.SetBool("isWalking", true);
        }
    

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);
            transform.position += currentSpeed * transform.forward * Time.deltaTime;

            edAnimator.SetBool("isWalking", true);
        }

        

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= currentSpeed * transform.forward * Time.deltaTime;

            edAnimator.SetBool("isWalkingBackwards", true);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed = runningSpeed;
                edAnimator.SetBool("isRunningBackwards", true);
            }
            else
            {
                currentSpeed = walkingSpeed;
                edAnimator.SetBool("isRunningBackwards", false);
            }
        }
        else
        {
            edAnimator.SetBool("isWalkingBackwards", false);
        }

        if (Input.GetKey(KeyCode.F))
        {
            edAnimator.SetBool("pickUP", true);
        }
        else 
        { 
            edAnimator.SetBool("pickUP", false);
        }

    }
}
