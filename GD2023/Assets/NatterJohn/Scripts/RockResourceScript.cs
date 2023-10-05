using System;
using System.Threading;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;

internal class RockResourceScript : MonoBehaviour
{ 

    float TIME_TO_COLLECT = 3;
    float timer;

    enum ResourceState { Idle, BeingHarvested }

    int typeId = 4; // 4 is rock
    int quantityInNode = 55;
    ResourceState currentState = ResourceState.Idle;


    MoveJammo harvesterJammo;

    internal void ImHarvestingYou(MoveJammo harvester)
    {
        print("Yikes I'm being harvested");
        harvesterJammo = harvester;
        startHarvestProcess();
    }

    private void startHarvestProcess();
    {
        currentState = ResourceState.BeingHarvested;
        timer = TIME_TO_COLLECT;

        GetComponent<Renderer>().material.color = Color.green;
    }
}

    void Start()
    {

    }

    void Update()
    {
        switch(currentState)
        {
            case ResourceState.BeingHarvested:

                timer -= Time.deltaTime;
                if (timer < 0)
                { 
                    harvesterJammo.give(quantityInNode, typeId)
                    theManager.ImHarvestingYou(this);
                    Destroy(gameObject);
                }
                if (harvesterJammo)
                {
                currentState = ResourceState.info
                endVisualEffect();
                }


                break;

            case ResourceState.Idle:

                break;
        }
    }
