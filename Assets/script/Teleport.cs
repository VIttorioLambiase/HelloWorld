using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public GameObject teleport;
   // float timer;
    public ForcePlayer tp;
    // Start is called before the first frame update
    void Start()
    {
        tp = GameObject.Find("Player").GetComponent<ForcePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && tp.canTp)
        {
            player.transform.position = teleport.transform.position;
            tp.tpTimer = 0;
            tp.canTp = false;
        }
    }
}
