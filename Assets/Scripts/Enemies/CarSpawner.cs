using System.IO;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public CarScript carPrefab;

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
            SpawnCar();
        }
    }

    void SpawnCar()
    {
        
        Instantiate(carPrefab, transform.position, Quaternion.identity);
        time = timeBetweenSpawn;
    }
}
