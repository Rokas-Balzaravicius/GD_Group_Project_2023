using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : HarvestableItem
{



    // Start is called before the first frame update
    void Start()
    {
        typeId = 1;
        quantityInNode = 30;
        cursorHoverId = 2;
        toolTipDescription = "Log of Wood, can burn or use in crafting";

    }

    // Update is called once per frame
    internal void Update()
    {
        base.Update();
    }


    internal override void startHarvestProcess()
    {
        print("Im a tree and Im being harvested");

        currentState = ResourceState.BeingHarvested;
        // start Timer
        timer = TIME_TO_COLLECT;
    }

    protected override void endVisualEffect()
    {
   
    }
}
