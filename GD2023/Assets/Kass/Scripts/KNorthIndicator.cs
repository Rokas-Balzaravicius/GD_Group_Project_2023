using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KNorthIndicator : MonoBehaviour
{
    public float sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(transform.forward, -sensitivity * Time.deltaTime);
        }
        else if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(transform.forward, sensitivity * Time.deltaTime);
        }
    }
}
