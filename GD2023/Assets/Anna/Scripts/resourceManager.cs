using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resourceManager : MonoBehaviour
{
    public Transform rockCloneTemplate;

    int number_of_rocks = 100;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < number_of_rocks; i++)
        {
            Instantiate(rockCloneTemplate,getRockSpawnLocation(), Quaternion.identity);
        }
    }

    private Vector3 getRockSpawnLocation()
    {
        return new Vector3(UnityEngine.Random.Range(-100f, 100f),0, UnityEngine.Random.Range(-100f, 100f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
