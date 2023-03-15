using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] int a = 1;
    [SerializeField] string b = "godo";
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"ciao {a}");
        Debug.Log(b);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
