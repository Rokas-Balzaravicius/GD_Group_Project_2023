using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KHarvestableItem;

public class KRockScript : KHarvestableItem
{
    public Invertory invertory;




    private void startVisualEffect()
    {
        // start Visual effect
        GetComponent<Renderer>().material.color = Color.green; ;
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
        base.Update();

    }


    internal override void startHarvestProcess()
    {
        currentState = ResourceState.BeingHarvested;
        // start Timer
        timer = TIME_TO_COLLECT;

        startVisualEffect();
    }

    protected override void endVisualEffect()
    {
        GetComponent<Renderer>().material.color = Color.white; ;
    }
}
