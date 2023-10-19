using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KMapScript : MonoBehaviour
{
    Vector3 offset = new Vector3(70, 70, 0);
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform parentTransform = transform.parent;
        Vector3 newSize = new Vector3((parentTransform.localScale.x/2), -(parentTransform.localScale.y/2), 0);
        Vector3 newPos = newSize - offset;
        transform.position = newPos;
    }
}
