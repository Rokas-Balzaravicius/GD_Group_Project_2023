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

    internal enum characterState { Idle, Walk }

    internal characterState currentlyIAm = characterState.Idle;

    Animator JammoAnimator;
    void Start()
    {
        JammoAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        switch (currentlyIAm)
        {
            case characterState.Idle:


                break;

            case characterState.Walk:




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
    }
}
