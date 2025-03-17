using UnityEngine;

public class B�sjSpawner : MonoBehaviour
{
    public GameObject b�sjPrefab;  // Prefab av b�sjeklatten
    public Transform spawnPosisjon; // Hvor b�sjen skal komme fra

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // N�r du hopper
        {
            SpawnB�sj();
        }
    }

    void SpawnB�sj()
    {
        Instantiate(b�sjPrefab, spawnPosisjon.position, Quaternion.identity);
    }
}
