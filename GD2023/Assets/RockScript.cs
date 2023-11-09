using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : HarvestableItem
{
    float TIME_TO_COLLECT = 3;
    float timer;


    enum ResourceState { Idle, BeingHarvested}


    ResourceState currentState = ResourceState.Idle;

    


    CharacterMovementScript charWhoIsHarvestingMe;
    ResourceManager theManager;
    public Invertory invertory;

    internal void ImHarvestingYou(HarvestableItem harvester)
    {
        print("Yikes Im being harvested");
       
        charWhoIsHarvestingMe = harvester;
        startHarvestProcess();
    }

    private void startHarvestProcess()
    {
        currentState = ResourceState.BeingHarvested;
        // start Timer
        timer = TIME_TO_COLLECT;

        startVisualEffect();
    }

    private void startVisualEffect()
    {
        // start Visual effect
        GetComponent<Renderer>().material.color = Color.green; ;
    }

    private void endVisualEffect()
    {
        // start Visual effect
        GetComponent<Renderer>().material.color = Color.white; ;
    }

    // Start is called before the first frame update
    void Start()
    {
        typeId = 4;
        quantityInNode = 55;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case ResourceState.BeingHarvested:

                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    // give the harvester the appropriate rescouces
                    charWhoIsHarvestingMe.give(quantityInNode, typeId);
                    theManager.IveBeenHarvested(this);
                    Destroy(gameObject);
                }

                if (charWhoIsHarvestingMe.currentlyIAm !=
                                CharacterMovementScript.characterState.Havesting)
                {
                    currentState = ResourceState.Idle;
                    endVisualEffect();

                }



                break;

            case ResourceState.Idle:


                break;

        }

        



    }

    internal void IamYourManager(ResourceManager resourceManager)
    {
        theManager = resourceManager; 
       
    }
}
