using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KNorthIndicator : MonoBehaviour
{

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(player.forward.z, player.forward.x) * Mathf.Rad2Deg;
        // Apply the rotation to the north indicator.
        transform.rotation = Quaternion.Euler(0, 0, -angle);
    }
}
