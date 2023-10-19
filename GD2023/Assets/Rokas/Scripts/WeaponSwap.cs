using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    Transform currentlyHolding;
    public GameObject[] AdjustedAxe, Sword1Adjusted;
    private int currentWeaponIndex = 0;

    void Start()
    {
        SwitchWeapon(currentWeaponIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            SwitchWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
        }
    }

    void SwitchWeapon(int weaponIndex)
    {
        AdjustedAxe[currentWeaponIndex].SetActive(false);

        currentWeaponIndex = weaponIndex;
        AdjustedAxe[currentWeaponIndex].SetActive(true);
    }

    internal void equip(PickUP newItem)
    {
        if (currentlyHolding !=  null)
        {

            currentlyHolding.transform.parent = null;
            currentlyHolding.position = transform.position;

            currentlyHolding.rotation = Quaternion.identity;


        }

        newItem.transform.parent = transform;
        newItem.transform.localPosition = Vector3.zero;
        newItem.transform.localRotation = Quaternion.identity;
        currentlyHolding = newItem.transform;


    }
}
