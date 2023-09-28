using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepScript : MonoBehaviour

    
{
    float walkingSpeed = 3;
    private float turningSpeed = 90;
    Animator sheepAnimator;
    // Start is called before the first frame update
    void Start()
    {
        sheepAnimator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {   ///   s            =         u                      *       t
            transform.position += walkingSpeed * transform.forward * Time.deltaTime;
            sheepAnimator.SetBool("isWalking", true);
        }
        else
            
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turningSpeed * Time.deltaTime);
        }
    }
}
