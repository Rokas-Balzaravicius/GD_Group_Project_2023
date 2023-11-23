using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : HarvestableItem
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
        typeId = 7;
        quantityInNode = 1;
        toolTipDescription = "Juicy delicious Pear, eat or use in Cooking";
        cursorHoverId = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
