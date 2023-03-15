using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public float speed;
    public bool MoveRight;

    // Use this for initialization
    void Update()
    {
        // Use this for initialization
        if (MoveRight == true)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            Flip();
        }
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Turn")
        {

            if (MoveRight == true)
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }
        }
    }
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.Rotate(0, 180, 0);


        MoveRight = !MoveRight;
    }
}