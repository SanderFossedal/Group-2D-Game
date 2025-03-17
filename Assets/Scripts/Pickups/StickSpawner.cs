using Unity.VisualScripting;
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
        SpawnStick();  // Starter første spawn
    }

    void SpawnStick()
    {
        float randomY = Random.Range(minY, maxY);
        GameObject newStick = Instantiate(stickPrefab, new Vector3(spawnX, randomY, 0), Quaternion.identity);
        newStick.AddComponent<StickMover>();

        // Velger en ny tilfeldig spawn-tid mellom minSpawnRate og maxSpawnRate
        float nextSpawnTime = Random.Range(minSpawnRate, maxSpawnRate);
        Invoke(nameof(SpawnStick), nextSpawnTime);
    }
}