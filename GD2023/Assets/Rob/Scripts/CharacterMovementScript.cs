using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{

    float walkingSpeed = 3;
    private float turningSpeed = 90;
    Animator jammoAnimator;

    // Start is called before the first frame update
    void Start()
    {
        jammoAnimator = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {   ///   s            =         u                      *       t
            transform.position += walkingSpeed * transform.forward * Time.deltaTime; ;
            jammoAnimator.SetBool("isWalking", true);
        }
        else
            jammoAnimator.SetBool("isWalking", false);

        if (Input.GetKey(KeyCode.A))
        {   
            transform.Rotate(Vector3.up, -turningSpeed*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);
        }




    }
}
