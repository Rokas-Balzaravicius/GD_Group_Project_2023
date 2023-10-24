using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    Transform currentlyHolding;

    private int currentWeaponIndex = 0;

    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {

    }



    internal void equip(PickUP newItem)
    {
        if (currentlyHolding !=  null)
        {
            print("1");

            currentlyHolding.transform.parent = null;
            currentlyHolding.position = transform.position;

            currentlyHolding.rotation = Quaternion.identity;


        }
        print("2");
        newItem.transform.parent = transform;
        newItem.transform.localPosition = Vector3.zero;
        newItem.transform.localRotation = Quaternion.identity;
        currentlyHolding = newItem.transform;


    }
}
