using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> groundObstacles;  
    public List<GameObject> airObstacles;     
    public float minSpawnInterval = 1.0f;   
    public float maxSpawnInterval = 1.5f;    
    public float groundYPosition = 0.55f;     
    public float minAirYPosition = 1.8f;   
    public float maxAirYPosition = 2.5f;    
    public float spawnXPosition = 15.0f;     

    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            bool spawnGroundObstacle = Random.value > 0.5f;

            GameObject selectedObstaclePrefab;
            float spawnYPosition;

            if (spawnGroundObstacle && groundObstacles.Count > 0)
            {
                int randomIndex = Random.Range(0, groundObstacles.Count);
                selectedObstaclePrefab = groundObstacles[randomIndex];
                spawnYPosition = groundYPosition;
            }
            else if (airObstacles.Count > 0)
            {
                int randomIndex = Random.Range(0, airObstacles.Count);
                selectedObstaclePrefab = airObstacles[randomIndex];
                spawnYPosition = Random.Range(minAirYPosition, maxAirYPosition);
            }
            else
            {
                yield return new WaitForSeconds(spawnInterval);
                continue;
            }

            Vector3 spawnPosition = new Vector3(spawnXPosition, spawnYPosition, 0);
            Instantiate(selectedObstaclePrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
