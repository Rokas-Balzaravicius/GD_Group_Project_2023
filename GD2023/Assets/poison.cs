using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poison : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        IHealth victim = collision.gameObject.GetComponent<IHealth>();
        if (victim != null)
        {
            victim.takeDamage(5);
        }
    }
}
