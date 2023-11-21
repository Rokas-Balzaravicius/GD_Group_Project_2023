using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot
{
    int quantity = 0;
    int type = 0;

    public InventorySlot(int quantity, int type)
    {
        this.quantity = quantity;
        this.type = type;
    }

    public InventorySlot() { }

    internal void  putAttempt(int quantity, int type)
    {
        this.quantity += quantity;
        this.type = type;
    }

    internal bool check(int quantityInNode, int typeId)
    {
        foreach (InventorySlot slot in Invertory) 
        {
            if(slot.type == typeId)
            { 
                return true; 
            }
        }
        return false;
    }
}
