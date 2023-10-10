using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JammoResources : MonoBehaviour
{


    public Transform rockCloneTemplate;

    int NUMBER_OF_ROCKS = 100;

    
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < NUMBER_OF_ROCKS; i++)
        {
            spawnRockinRandomLocation();
        }

    }

    private void spawnRockinRandomLocation()
    {
        List<RockResourceScript> JammoResources.allRocks;
        Transform newRocktf = Instantiate(rockCloneTemplate, getRockSpawnLocation(), Quaternion.identity);
        RockResourceScript newRock = newRocktf.GetComponent<RockResourceScript>();
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

    internal void IveBeenHarvested(RockResourceScript rockResourceScript)
    {
        print("Spawning new Rock");



        allRocks.Remove(rockResourceScript);


    }
}
