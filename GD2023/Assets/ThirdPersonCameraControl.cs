using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdpersoncameracontrol : MonoBehaviour
{
    public float desiredAngle = 0;
    private float bufferZone = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localRotation.eulerAngles.y < desiredAngle - bufferZone)
        {
            print("Adding 1");
            transform.RotateAround(transform.parent.position, Vector3.up, 1);
        }
        else
            if (transform.localRotation.eulerAngles.y > desiredAngle + bufferZone)
            {
                print("Subtracting");
                print("Euler y is " + transform.localRotation.eulerAngles.y.ToString());
                print("Desired Angle " + desiredAngle.ToString() + " + buffer of " + bufferZone.ToString());
                transform.RotateAround(transform.parent.position, Vector3.up, -1);
            }

    }
}
