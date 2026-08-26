using UnityEngine;

public class DifficultyManager_Logic : MonoBehaviour
{
    [Header ("Spawnable Prefabs")]
    public GameObject[] prefabsToSpawn;

    private void Start()
    {
        SpawnRandomPrefab();
    }

    void SpawnRandomPrefab()
    {
        if (prefabsToSpawn.Length == 0) return;

        int randomIndex = Random.Range(0, prefabsToSpawn.Length);

        Vector2 randomPosition = new Vector2(Random.Range(-8f, 8f), Random.Range(-5f, 5f));

        Instantiate(prefabsToSpawn[randomIndex], randomPosition, Quaternion.identity);
    }

}
