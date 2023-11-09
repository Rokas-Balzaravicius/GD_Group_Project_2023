using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invertory : MonoBehaviour
{
    List<InventorySlot> allSlots = new List<InventorySlot>();
    int numberOfInventorySlots, defaultNumberOfINventorySlots = 10;
    internal void put(int quantityInNode, int typeId)
    {
        for (int i = 0; i < numberOfInventorySlots; i++)
        {
            InventorySlot slot = allSlots[i];
            if (slot.check(quantityInNode, typeId))
            {
                slot.putAttempt(quantityInNode, typeId);
                break;
            }
        }

    }

        // Start is called before the first frame update
        void Start()
        {
            numberOfInventorySlots = defaultNumberOfINventorySlots;
            for (int i = 0; i < numberOfInventorySlots; i++)
            {
                allSlots.Add(new InventorySlot());
            }
        }

        // Update is called once per frame
        void Update()
        {

        }


    
}
