using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseControl : MonoBehaviour
{
    float walkingSpeed = 3;
    private float turningSpeed = 90;
    Animator HorseAnimator;

    // Start is called before the first frame update
    void Start()
    {
        HorseAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {   ///   s            =         u                      *       t
            transform.position += walkingSpeed * transform.forward * Time.deltaTime;
            HorseAnimator.SetBool("isWalking", true);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += walkingSpeed * 2 * transform.forward * Time.deltaTime;
            HorseAnimator.SetBool("isRunning", true);
        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turningSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);
        }




    }
}
