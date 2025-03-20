using System.Collections;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    //Dette scriptet kan bli oppgradert i framtiden til å ta flere prefabs, hvis man har flere variasjoner av en enemy

    [Header("Prefab")]
    [Tooltip("The prefab to spawn.")]
    [SerializeField] private GameObject prefab;

    [Header("Spawn Timing")]
    [Tooltip("Time to wait before starting the spawn cycle.")]
    public float startDelay = 0f;
    [Tooltip("Minimum delay between spawns.")]
    [SerializeField] private float minSpawnTime = 1f;
    [Tooltip("Maximum delay between spawns.")]
    [SerializeField] private float maxSpawnTime = 5f;

    [Header("Spawn Locations")]
    [Tooltip("List of potential spawn points. One will be chosen at random.")]
    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {

        // Sjekker om listen er tom, funker ikke da
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points provided for PrefabSpawner. Please assign at least one spawn point.");
            return;
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        // Venter med å execute noe før de sekundene har gått
        yield return new WaitForSeconds(startDelay);

        //Kinda sketch med en uendelig true statement, men oh well
        while (true)
        {
            //Velger en tilfeldig tall som vente tid, valget blir gjort mellom min og max, inkludert min og max 
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            //Unity metode for å vente i sekunder, bedre enn å bruke delta time og slikt
            yield return new WaitForSeconds(waitTime);




            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)]; //Velget et tilfeldig spawnpoint
            SpawnPrefab(spawnPoint.position, spawnPoint.rotation);
        }
    }
    private void SpawnPrefab(Vector3 position, Quaternion rotation)
    {
        Instantiate(prefab, position, rotation);
    }
}
