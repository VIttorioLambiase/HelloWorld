using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPlayer : MonoBehaviour
{
    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {         
           collision.gameObject.transform.SetParent(transform);
        }
    }
    
    private void OnCollisionExit(Collision collision)
    {
        
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.transform.SetParent(null);
            }
        
    }
}
