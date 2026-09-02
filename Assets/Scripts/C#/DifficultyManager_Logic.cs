using UnityEngine;

public class DifficultyManager_Logic : MonoBehaviour
{
    public static DifficultyManager_Logic Instance;
    public PopupManager_Logic PopupManager;

    [Header ("Spawnable Prefabs")]
    public GameObject[] prefabsToSpawn;

    [Header ("Spawn Area")]
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -3f; // I do not know why this works this way 
    public float maxY = -3f; // These should be able to be a range but it does not like it

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
