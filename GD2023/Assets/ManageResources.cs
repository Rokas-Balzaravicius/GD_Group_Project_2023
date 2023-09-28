using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageResources : MonoBehaviour
{


    public Transform rockCloneTemplate;

    int NUMBER_OF_ROCKS = 100;

    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < NUMBER_OF_ROCKS; i++)
        {
            Instantiate(rockCloneTemplate, getRockSpawnLocation(), Quaternion.identity);
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
}
