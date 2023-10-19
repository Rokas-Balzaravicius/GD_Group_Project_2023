using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    List<RockScript> allRocks;
    public Transform rockCloneTemplate;

    int NUMBER_OF_ROCKS = 100;

    // Start is called before the first frame update
    void Start()
    {
        allRocks = new List<RockScript>();
        for (int i = 0; i < NUMBER_OF_ROCKS; i++)
        {
            spawnRockinRandomLocation();
        }

    }

    private void spawnRockinRandomLocation()
    {
        Transform newRocktf = Instantiate(rockCloneTemplate, getRockSpawnLocation(), Quaternion.identity);
        RockScript newRock = newRocktf.GetComponent<RockScript>();
        newRock.IamYourManager(this);
        allRocks.Add(newRock);
    }

    private Vector3 getRockSpawnLocation()
    {
        return new Vector3(UnityEngine.Random.Range(-100f, 100f), 0, UnityEngine.Random.Range(-100f, 100f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void IveBeenHarvested(RockScript rockScript)
    {
        print("Spawning new Rock");

        // remove from list

        allRocks.Remove(rockScript);


    }
}
