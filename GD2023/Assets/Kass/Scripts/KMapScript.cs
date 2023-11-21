using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMapScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(70, 70, 0);
        Transform parentTransform = transform.parent;
        //transform.localScale = new Vector3(parentTransform.localScale.x / 1920, parentTransform.localScale.y / 1080, 1);
        Vector3 newSize = new Vector3((parentTransform.localScale.x / 2), -(parentTransform.localScale.y / 2), 0);
        Vector3 newPos = (newSize - offset);
        print(newPos);
        transform.position = newPos;
    }
}
