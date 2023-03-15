using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passable : MonoBehaviour
{
    ForcePlayer jump;
    public Rigidbody player;
    float timer = 0f;
    private bool isOn = false;
    public bool isIn = false;
    // Start is called before the first frame update
    void Start()
    {
        jump = GameObject.Find("Player").GetComponent<ForcePlayer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isOn == true && (Input.GetKey("s") && isIn == false))
        {
            Debug.Log("Godo");
            gameObject.GetComponent<Collider>().isTrigger = true;
            timer += Time.deltaTime;
        }


        

        if (player.velocity.y > 0.1f && Input.GetKey("space"))
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
        }

        if (player.velocity.y < 0 && !Input.GetKey("s") && isIn == false)
        {
            gameObject.GetComponent<Collider>().isTrigger = false;
        }

        if (isIn== true) 
        { 
            jump.canjump= false;
        }    
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            isOn = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isOn = false;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
       if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Collider>().isTrigger = false;
            timer = 0;
            isOn = false;
            isIn= false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
            timer = 0;
            isIn = true;
        }
    }

}
