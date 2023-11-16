using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using Unity.VisualScripting;
using UnityEngine;

public class MoveJammo : MonoBehaviour
{
    float currentSpeed = 2;
    float walkingSpeed = 2;
    float runningSpeed = 4;

    float checkDistance = 1;
    float checkRadius = 0.5f;
    private float turningSpeed = 130;
   
    internal enum characterState { Idle, Walk, Harvesting }

    internal characterState currentlyIAm = characterState.Idle;

    CursorManager cursorManager;
    Animator JammoAnimator;
    void Start()
    {
        JammoAnimator = GetComponent<Animator>();
        cursorManager = FindObjectOfType<CursorManager>();
    }

    void Update()
    {
        switch (currentlyIAm)
        {
            case characterState.Idle:


                break;

            case characterState.Walk:



            case characterState.Harvesting:

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    currentlyIAm = characterState.Idle;
                }

                break;
        }
        JammoAnimator.SetBool("isWalking", false);

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= currentSpeed * transform.forward * Time.deltaTime;

            JammoAnimator.SetBool("isWalking", true);
        }
        else
        {
            JammoAnimator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turningSpeed * Time.deltaTime);
            transform.position += currentSpeed * transform.forward * Time.deltaTime;

            JammoAnimator.SetBool("isWalking", true);
        }
        else
        {
            JammoAnimator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);
            transform.position += currentSpeed * transform.forward * Time.deltaTime;

            JammoAnimator.SetBool("isWalking", true);
        }
        else
        {
            JammoAnimator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.W))
        {   ///   s            =         u                      *       t
            transform.position += currentSpeed * transform.forward * Time.deltaTime;
            JammoAnimator.SetBool("isWalking", true);
        }
        else
        {
            JammoAnimator.SetBool("isWalking", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (cursorManager.isCurrentTexture(2)) { 
                // Harvest Check
                Collider[] allPossibleInteractives = Physics.OverlapSphere(transform.position + checkDistance * transform.forward, checkRadius);
                print("Found " + allPossibleInteractives.Length.ToString());

                foreach (Collider c in allPossibleInteractives)
                {
                    if (currentlyIAm != characterState.Harvesting)
                    {
                    RockScript myRock = c.GetComponent<RockScript>();
                    if (myRock != null)
                    {
                        print("I found a rock");
                       // myRock.ImHarvestingYou(moveJammo: this);
                        currentlyIAm = characterState.Harvesting;

                    }
                }


                PickUP newItem = c.GetComponent<PickUP>();
                if (newItem != null)
                {
                    print("I found an item");

                }

            }
        }
        }
    }
}
