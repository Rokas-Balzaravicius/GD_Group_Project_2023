using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KHarvestableItem;

public class KTreeScript : KHarvestableItem
{



    // Start is called before the first frame update
    void Start()
    {
        typeId = 1;
        quantityInNode = 30;
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
        throw new System.NotImplementedException();
    }
}
