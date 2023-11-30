using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour,IHealth
{

    Invertory charInventory;

    float currentSpeed = 2;
    float walkingSpeed = 2;
    float runningSpeed = 4;

    TooltipManager tooltipManager;
    /// <summary>
    /// The distance to the centre of the sphere used to check for interactable objects
    /// </summary>
    float checkDistance = 1;
    float checkRadius = 0.5f;
    private float turningSpeed = 130;

    internal enum characterState { Idle, Walk, Run, Pickup, Havesting}

    internal characterState currentlyIAm   = characterState.Idle;
    Animator edAnimator;
    WeaponSwap handsControl;
    private int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        tooltipManager = FindAnyObjectByType<TooltipManager>();
        handsControl = GetComponentInChildren<WeaponSwap>();
        edAnimator = GetComponent<Animator>();
        charInventory = GetComponent<Invertory>();

    }

    // Update is called once per frame
    void Update()
    {
        switch(currentlyIAm)
        {
            case characterState.Idle:

                
                break;

            case characterState.Walk:




                break;
            case characterState.Run:


                break

                    ; case characterState.Pickup:


                break;

            case characterState.Havesting:

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    currentlyIAm = characterState.Idle;
                    edAnimator.SetBool("isMining", false);
                }

                break;
        }

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

        if (Input.GetKeyDown(KeyCode.F))
        {
            // Harvest Check
            Collider[] allPossibleInteractives = Physics.OverlapSphere(transform.position + checkDistance * transform.forward, checkRadius);
            print("Found " + allPossibleInteractives.Length.ToString());
            
            foreach (Collider c in allPossibleInteractives)
            {   if (currentlyIAm != characterState.Havesting)
                {
                    HarvestableItem myItem = c.GetComponent<HarvestableItem>();
                    if (myItem != null)
                    {
                        print("I found an item");
                        myItem.ImHarvestingYou(this);
                        currentlyIAm = characterState.Havesting;
                        edAnimator.SetBool("isMining", true);

                    }
                }


                PickUP newItem = c.GetComponent<PickUP>();
                if (newItem != null)
                {
                    print("I found an item");
                    handsControl.equip(newItem);

                }

            }
           
        }
        else 
        { 
      
        }
    }


    private void OnCollisionEnter(Collision collision) 
    {
        print("Ouch!!! I just hit a "+ collision.gameObject.name);
        
    }


    internal void give(int quantityInNode, int typeId)
    {
        // place in inventory

        print(" have just received " + quantityInNode.ToString() + " of type"
             + typeId.ToString()); 

        if (currentlyIAm == characterState.Havesting) {
            
            currentlyIAm = characterState.Idle;
            edAnimator.SetBool("isMining", false);
        }

        charInventory.put(quantityInNode, typeId);

    }

    public void takeDamage(int damage)
    {
       health-=damage;
     
        if (health < 0) { Destroy(gameObject); }
        print("Ouch my health is now " + health.ToString());
    }
}
