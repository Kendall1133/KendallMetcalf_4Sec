using UnityEngine;

public class DifficultyManager_Logic : MonoBehaviour
{
    public static DifficultyManager_Logic Instance;

    [Header ("Spawnable Prefabs")]
    public GameObject[] prefabsToSpawn;

    [Header ("Spawn Area")]
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -3f;
    public float maxY = 3f;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnRandomPrefab();
    }

    public void SpawnRandomPrefab()
    {
        if (prefabsToSpawn.Length == 0) return;

        int randomIndex = Random.Range(0, prefabsToSpawn.Length);

        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(-minY, maxY));

        Instantiate(prefabsToSpawn[randomIndex], randomPosition, Quaternion.identity);

    }
}
