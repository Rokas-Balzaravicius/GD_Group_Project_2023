using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KCameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensitivity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Camera Movement
        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(transform.up, -sensitivity * Time.deltaTime);
        }
        else if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(transform.up, sensitivity * Time.deltaTime);
        }

        //if (Input.GetAxis("Mouse Y") < 0)
        //{
        //    transform.Rotate(transform.forward, -sensitivity * Time.deltaTime);
        //}
        //else if (Input.GetAxis("Mouse Y") > 0)
        //{
        //    transform.Rotate(transform.forward, sensitivity * Time.deltaTime);
        //}
    }
}
