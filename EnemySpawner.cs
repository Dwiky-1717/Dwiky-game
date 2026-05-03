using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // prefab enemy
    public float spawnDelay = 3f;    // jeda spawn
    public int maxEnemy = 5;         // batas maksimal enemy

    private int currentEnemy = 0;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnDelay);
    }

    void SpawnEnemy()
    {
        // kalau sudah mencapai batas, stop spawn
        if (currentEnemy >= maxEnemy)
            return;

        // spawn enemy
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        // tambah jumlah enemy
        currentEnemy++;
    }
}