using System.IO;
using UnityEngine;

public class CraneSpawner : MonoBehaviour
{
    public EnemyCrane cranePrefab;

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
            SpawnCrane();
        }
    }

    void SpawnCrane()
    {

        Instantiate(cranePrefab, transform.position, Quaternion.identity);
        time = timeBetweenSpawn;
    }
}
