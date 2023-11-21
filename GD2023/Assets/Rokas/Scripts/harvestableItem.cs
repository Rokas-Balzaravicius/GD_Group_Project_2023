using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HarvestableItem : MonoBehaviour
{
    internal ResourceManager theManager;


    internal int typeId; 
    internal int quantityInNode;

    /// <summary>
    /// Id which links the appropriate mouse pointer image when hovering over it
    /// </summary>
    internal int cursorHoverId;


    internal string toolTipDescription;


    internal CharacterMovementScript charWhoIsHarvestingMe;
    internal float TIME_TO_COLLECT = 3;
    internal float timer;


    internal enum ResourceState { Idle, BeingHarvested }


    internal ResourceState currentState = ResourceState.Idle;



 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    internal void Update()
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

    internal void ImHarvestingYou(CharacterMovementScript character)
    {
        print("Yikes Im being harvested");

        charWhoIsHarvestingMe = character;
        startHarvestProcess();
    }

    internal abstract void startHarvestProcess();
    protected abstract void endVisualEffect();
}
