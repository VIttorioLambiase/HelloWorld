using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnTime = 3;
    private float spawnTimer = 0;
    
    public float areaWidth = 5;
    public float areaHeight = 10;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnTime)
        {
            Vector3 spawnPos = new Vector3();
            spawnPos.x = transform.position.x + Random.Range(-areaWidth / 2, areaWidth / 2);
            spawnPos.y = transform.position.y + Random.Range(-areaHeight / 2, areaHeight / 2);

            GameObject obj = Instantiate(objectToSpawn, spawnPos, Quaternion.identity, transform);
            spawnTimer = 0;

            obj.name = "godolo";
        }
    }


}
