using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMapZoomScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        while (transform.position.y < 100)
        {
            if (Input.GetKey(KeyCode.M) && Input.GetKeyDown(KeyCode.Tab))
            {
                transform.position += new Vector3(0, 40, 0);
            }
        }
        transform.position = new Vector3(0, 10, 0);
    }
}
