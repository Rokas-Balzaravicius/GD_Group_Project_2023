using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnaRockScript : MonoBehaviour
{
    AnnaMovementScript charWhoIsHarvestingMe;
    internal void IMHarvestinYou(AnnaMovementScript harvester)
    {
        print("Yikes im been harvesting");
        startHarvestProcess();
    }

    private void startHarvestProcess()
    {
        //start timer
        //start Visual effect
        GetComponent<Renderer>().material.color = Color.green;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
