using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    List<RockScript> allRocks;
        List<TreeScript> allTrees;
    public Transform rockCloneTemplate;
    public Transform treeCloneTemplate;

    int NUMBER_OF_ROCKS = 100;

    // Start is called before the first frame update
    void Start()
    {
        allRocks = new List<RockScript>();
        allTrees = new List<TreeScript>();

        for (int i = 0; i < NUMBER_OF_ROCKS; i++)
        {
            spawnCloneinRandomLocation(rockCloneTemplate);
            spawnCloneinRandomLocation(treeCloneTemplate);
        }

    }

    private void spawnCloneinRandomLocation(Transform clone)
    {
        Transform newClonetf =
            Instantiate(clone, getRockSpawnLocation(), Quaternion.identity);
        
        
        RockScript newRock = newClonetf.GetComponent<RockScript>();
        if (newRock != null)
        {
            newRock.IamYourManager(this);
            allRocks.Add(newRock);
        }
        TreeScript newTree = newClonetf.GetComponent<TreeScript>();
        if (newTree != null)
        {
            newTree.IamYourManager(this);
            allTrees.Add(newTree);
        }

    }

    private Vector3 getRockSpawnLocation()
    {
        return new Vector3(UnityEngine.Random.Range(-100f, 100f), 0, UnityEngine.Random.Range(-100f, 100f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void IveBeenHarvested(HarvestableItem harvestScript)
    {
        print("Spawning new Rock");

        // remove from list
        if (harvestScript is RockScript)
            allRocks.Remove(harvestScript as RockScript);


    }
}
