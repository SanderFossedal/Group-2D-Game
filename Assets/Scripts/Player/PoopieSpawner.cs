using UnityEngine;

public class BæsjSpawner : MonoBehaviour
{
    public GameObject bæsjPrefab;  // Prefab av bæsjeklatten
    public Transform spawnPosisjon; // Hvor bæsjen skal komme fra

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Når du hopper
        {
            SpawnBæsj();
        }
    }

    void SpawnBæsj()
    {
        Instantiate(bæsjPrefab, spawnPosisjon.position, Quaternion.identity);
    }
}
