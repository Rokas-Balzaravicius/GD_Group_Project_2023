using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJammo : MonoBehaviour
{

    float walkingSpeed = 3;
    private float turningSpeed = 90;
    /// <summary>
    /// The distance to the centre of the sphere used to check for interactable objects
    /// </summary>
    float checkDistance = 1;
    float checkRadius = 0.5f;


    internal enum characterState { Idle, Walk, Run, Pickup, Harvesting };

    internal characterState currentlyIAm = characterState.Idle;
    Animator jammoAnimator;

    // Start is called before the first frame update
    void Start()
    {
        jammoAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentlyIAm)
        {
            case characterState.Idle:


                break;

            case characterState.Walk:




                break;
            case characterState.Run:


                break

                    ;
            case characterState.Pickup:


                break;

            case characterState.Harvesting:

                if (Input.GetKeyDown(KeyCode.Space))
                    currentlyIAm = characterState.Idle;

                break;

        }
        if (Input.GetKey(KeyCode.S))
        {   ///   s            =         u                      *       t
            transform.position += -walkingSpeed * transform.forward * Time.deltaTime; ;
            jammoAnimator.SetBool("isWalking", true);
        }
        else
            jammoAnimator.SetBool("isWalking", false);

        if (Input.GetKey(KeyCode.W))
        {   ///   s            =         u                      *       t
            transform.position += walkingSpeed * transform.forward * Time.deltaTime; ;
            jammoAnimator.SetBool("isWalking", true);
        }
        else
            jammoAnimator.SetBool("isWalking", false);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turningSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.F)) 
        {
            // Harvest Check
            Collider[] allPossibleInteractives = Physics.OverlapSphere(transform.position + checkDistance * transform.forward, checkRadius);
            print("Found " + allPossibleInteractives.Length.ToString());
            foreach (Collider c in allPossibleInteractives)
            {
                RockScript myRock = c.GetComponent<RockScript>();
                if (myRock != null)
                {
                    print("I found a rock");


                    //myRock.ImHarvestingYou(this);
                    currentlyIAm = characterState.Harvesting;



                }

            }
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Ouch!!! I just hit a " + collision.gameObject.name);
    }

    internal void give(int quantityInNode, int typeId)
    {
        throw new NotImplementedException();
    }
}
