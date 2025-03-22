using System.Collections;
using UnityEngine;

public class StickSpawner : MonoBehaviour
{

    public GameObject stickPrefab;

    [SerializeField] private float spawnX = 10f;
    [SerializeField] private float minY = -5f;
    [SerializeField] private float maxY = 5f;
    [SerializeField] private float minSpawnRate = 5f;
    [SerializeField] private float maxSpawnRate = 20f;

    void Start()
    {
        StartCoroutine(SpawnSticks());
    }


    private IEnumerator SpawnSticks()
    {
        while (true)
        {
            SpawnStick();

            // Wait for a random time before spawning the next stick
            float spawnDelay = Random.Range(minSpawnRate, maxSpawnRate);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnStick()
    {

        // Randomize Y position between minY and maxY
        float spawnY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

        // Instantiate the stickPrefab at the calculated position with no rotation
        Instantiate(stickPrefab, spawnPosition, Quaternion.identity);


        //float randomY = Random.Range(minY, maxY);
        //GameObject newStick = Instantiate(stickPrefab, new Vector3(spawnX, randomY, 0), Quaternion.identity);
        //newStick.AddComponent<StickSettings>(); Trenger ikke å adde dette siden scriptet er allerede på prefaben

        //// Velger en ny tilfeldig spawn-tid mellom minSpawnRate og maxSpawnRate
        //float nextSpawnTime = Random.Range(minSpawnRate, maxSpawnRate);
        //Invoke(nameof(SpawnStick), nextSpawnTime);
    }
}