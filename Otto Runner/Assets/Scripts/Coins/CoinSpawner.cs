using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;

    public float minSpawnInterval = 0.2f;  
    public float maxSpawnInterval = 0.3f; 
    public float minYPosition = 0.7f;     
    public float maxYPosition = 5f;      
    public float spawnXPosition = 15.0f;

    private bool stopSpawnCoins = true;

    public bool StopSpawnCoins { get => stopSpawnCoins; set => stopSpawnCoins = value; }

    void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins()
    {
        while (stopSpawnCoins)
        {
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            float spawnYPosition = Random.Range(minYPosition, maxYPosition);

            Vector3 spawnPosition = new Vector3(spawnXPosition, spawnYPosition, 0);

            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
