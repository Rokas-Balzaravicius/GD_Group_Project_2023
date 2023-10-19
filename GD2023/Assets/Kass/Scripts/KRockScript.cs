using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KRockScript : MonoBehaviour
{
    KCharacterMovement charWhoIsHarvestingMe;

    internal void ImHavestingYou(KCharacterMovement harvester)
    {
        print("Yikes Im being harvested");
        charWhoIsHarvestingMe = harvester;
        startHarvestProcess();
    }

    private void startHarvestProcess()
    {
        // start Timer
        // start Visual effect
        GetComponent<Renderer>().material.color = Color.green; ;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
