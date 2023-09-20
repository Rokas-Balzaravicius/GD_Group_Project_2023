using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{

    float walkingSpeed = 3;
    private float turningSpeed = 90;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {   ///   s            =         u                      *       t
            transform.position +=walkingSpeed * transform.forward * Time.deltaTime; ;
        }
        if (Input.GetKey(KeyCode.A))
        {   
            transform.Rotate(Vector3.up, -turningSpeed*Time.deltaTime);
        }




    }
}
