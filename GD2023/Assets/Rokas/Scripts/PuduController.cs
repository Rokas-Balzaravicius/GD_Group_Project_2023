using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuduController : MonoBehaviour
{
    float walkingSpeed = 3;
    float runningSpeed = 5;
    private float turningSpeed = 90;
    Animator puduAnimator;

    // Start is called before the first frame update
    void Start()
    {
        puduAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        puduAnimator.SetBool("isWalking", false);

        if (Input.GetKey(KeyCode.W))
        {   ///   s            =         u                      *       t
            transform.position += walkingSpeed * transform.forward * Time.deltaTime;

            puduAnimator.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turningSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position+= runningSpeed * transform.forward* Time.deltaTime;

            puduAnimator.SetBool("isRunning", true);

        }

        else
        {
            puduAnimator.SetBool("isRunning", false) ;
        }

    }

    
    

}