using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : HarvestableItem
{
    protected override void endVisualEffect()
    {

    }

    internal override void startHarvestProcess()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        typeId = 2;
        quantityInNode = 100;
        toolTipDescription = "Money given to you by an NPC. How kind of them!";
        cursorHoverId = 4;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
