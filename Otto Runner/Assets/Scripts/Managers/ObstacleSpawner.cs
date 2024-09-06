using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> groundObstacles; //Obstaculos del piso (macetas)
    [SerializeField] List<GameObject> airObstacles;    //Obstáculos del aire (pajaros)
    [SerializeField] List<GameObject> crouchObstacles;  //Obstáculos para deslizarse (personas)
    [SerializeField] List<GameObject> benchObstacles;  //Obstáculos que incluyen un banquito y una maceta


    [SerializeField] float minSpawnInterval = 1.0f;
    [SerializeField] float maxSpawnInterval = 1.5f;
    [SerializeField] float groundYPosition = 0.55f;   
    [SerializeField] float crouchYPosition = 1.0f;    
    [SerializeField] float minAirYPosition = 1.8f;     
    [SerializeField] float maxAirYPosition = 2.5f;    
    [SerializeField] float spawnXPosition = 15.0f;     

    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            float obstacleType = Random.value;
            GameObject selectedObstaclePrefab;
            float spawnYPosition;

            if (obstacleType <= 0.33f && crouchObstacles.Count > 0)
            {
                int randomIndex = Random.Range(0, crouchObstacles.Count);
                selectedObstaclePrefab = crouchObstacles[randomIndex];
                spawnYPosition = crouchYPosition;
            }
            else if (obstacleType <= 0.66f && groundObstacles.Count > 0)
            {
                int randomIndex = Random.Range(0, groundObstacles.Count);
                selectedObstaclePrefab = groundObstacles[randomIndex];
                spawnYPosition = groundYPosition;
            }
            else if (obstacleType <= 0.99f && benchObstacles.Count > 0)
            {
                int randomIndex = Random.Range(0, benchObstacles.Count);
                selectedObstaclePrefab = benchObstacles[randomIndex];
                spawnYPosition = crouchYPosition;
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
