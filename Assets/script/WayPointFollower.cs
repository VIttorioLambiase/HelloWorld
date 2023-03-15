using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] wayPoints;
    int currentWayPointIndex = 0;

    [SerializeField] float speed = 1f;

    int dir = 1;


    void Start()
    {
        
    }

    
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentWayPointIndex].transform.position, speed * Time.deltaTime);
        if (currentWayPointIndex >= wayPoints.Length -1)
        {
            dir = -1;
        }

        if (currentWayPointIndex == 0)
        {
            dir = 1;
        }

        if (Vector3.Distance(transform.position, wayPoints[currentWayPointIndex].transform.position) < .1f)
        {
            currentWayPointIndex = currentWayPointIndex + 1 * dir;
        }


        

    }
}
