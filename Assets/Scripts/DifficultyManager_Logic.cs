using UnityEngine;

public class DifficultyManager_Logic : MonoBehaviour
{
    public static DifficultyManager_Logic Instance;

    [Header ("Difficulty Settings")]
    // The starting lifetime for the very first object (in seconds)
    [SerializeField] private float currentLifetime = 5.0f;

    // How much to reduce the lifetime per click (e.g., 10% faster)
    [SerializeField] private float speedUpMultiplier = 0.9f;

    // Minimum cap so the game doesn't become impossible
    [SerializeField] private float minimumLifetime = 0.5f;

    [Header ("Spawnable Prefabs")]
    public GameObject[] prefabsToSpawn;

    [Header ("Spawn Area")]
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -2f;
    public float maxY = 2f;

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
    public void OnObjectClicked()
    {
        // 1. Decrease the lifetime for the next object
        currentLifetime *= speedUpMultiplier;

        // 2. Ensure it doesn't drop below the minimum threshold
        if (currentLifetime == minimumLifetime)
        {

            currentLifetime = minimumLifetime;

        }
    }
}
