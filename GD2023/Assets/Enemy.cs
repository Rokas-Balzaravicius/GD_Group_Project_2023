using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : HarvestableItem
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
        typeId = 3;
        quantityInNode = 3;
        toolTipDescription = "Skin acquired by killing a snake. Use to craft armour.";
        cursorHoverId = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
