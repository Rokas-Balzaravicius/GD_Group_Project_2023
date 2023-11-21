using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KResourceManager : MonoBehaviour
{

    List<KRockScript> allRocks;
    List<KTreeScript> allTrees;
    public Transform rockCloneTemplate;
    public Transform treeCloneTemplate;

    int NUMBER_OF_ROCKS = 100;

    // Start is called before the first frame update
    void Start()
    {
        allRocks = new List<KRockScript>();
        allTrees = new List<KTreeScript>();

        for (int i = 0; i < NUMBER_OF_ROCKS; i++)
        {
            spawnCloneinRandomLocation(rockCloneTemplate);
            spawnCloneinRandomLocation(treeCloneTemplate);
        }

    }

    private void spawnCloneinRandomLocation(Transform clone)
    {
        Transform newClonetf = Instantiate(clone, getRockSpawnLocation(), Quaternion.identity);


        KRockScript newRock = newClonetf.GetComponent<KRockScript>();
        if (newRock != null)
        {
            newRock.IamYourManager(this);
            allRocks.Add(newRock);
        }
        KTreeScript newTree = newClonetf.GetComponent<KTreeScript>();
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

    internal void IveBeenHarvested(KHarvestableItem harvestScript)
    {
        print("Spawning new Rock");

        // remove from list
        if (harvestScript is KRockScript)
            allRocks.Remove(harvestScript as KRockScript);


    }
}
