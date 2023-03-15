using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherGround : MonoBehaviour
{
    public bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Terrain")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Terrain")
        {
            isGrounded = false;
        }
    }
}
