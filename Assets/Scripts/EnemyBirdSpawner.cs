using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEngine;

public class EnemyBirdSpawner : MonoBehaviour
{
    public EnemyBird enemyBirdPrefab;
    public List<Transform> spawnPoints = new();
    private float time;
    public float timeBetweenSpawn;
    //Burde sikkert lage en range av spawnrates i stedet for et fixed nummer ^

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time = time - Time.deltaTime;
        if (time < 0)
        {
            SpawnEnemyBird();
        }
    }

    void SpawnEnemyBird()
    {
        Vector3 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
        Instantiate(enemyBirdPrefab, spawnPoint, Quaternion.identity);
        time = timeBetweenSpawn;
    }
}
