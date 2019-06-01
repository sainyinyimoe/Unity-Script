using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    Transform[] spawnPoints;
    [SerializeField] float timeBetweenEachSpawn = 3;
    float timer = 0;

    void Start()
    {
        timer = timeBetweenEachSpawn;
             
        spawnPoints = new Transform[transform.childCount];

        for  (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i] = transform.GetChild(i);
        }
                      
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeBetweenEachSpawn)
        {
            timer = 0;

            Instantiate(enemyPrefab,
                        spawnPoints[Random.Range(0,spawnPoints.Length)].position,
                        Quaternion.identity);
        }
    }

}
