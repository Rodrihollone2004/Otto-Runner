using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gameManager; 
    private DistanceCounter distanceCounter;

    [SerializeField] List<GameObject> groundObstacles; // Obstaculos del piso (macetas)
    [SerializeField] List<GameObject> airObstacles;    // Obstáculos del aire (pájaros)
    [SerializeField] List<GameObject> crouchObstacles;  // Obstáculos para deslizarse (personas)
    [SerializeField] List<GameObject> benchObstacles;  // Obstáculos que incluyen un banquito y una maceta

    [SerializeField] float minSpawnInterval = 1.0f;
    [SerializeField] float maxSpawnInterval = 1.5f;
    [SerializeField] float groundYPosition = 0.55f;
    [SerializeField] float crouchYPosition = 1.0f;
    [SerializeField] float minAirYPosition = 1.8f;
    [SerializeField] float maxAirYPosition = 3.5f;
    [SerializeField] float spawnXPosition = 15.0f;

    void Start()
    {
        if (gameManager != null)
        {
            distanceCounter = gameManager.GetComponent<DistanceCounter>();

            if (distanceCounter == null)
            {
                Debug.LogError("No se encontró el componente DistanceCounter en el GameManager.");
            }
        }
        else
        {
            Debug.LogError("GameManager no asignado en el ObstacleSpawner.");
        }

        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float distance = distanceCounter != null ? distanceCounter.GetDistance() : 0f;
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            List<GameObject> availableObstacles = GetAvailableObstacles(distance);

            if (availableObstacles.Count > 0)
            {
                int randomIndex = Random.Range(0, availableObstacles.Count);
                GameObject selectedObstaclePrefab = availableObstacles[randomIndex];

                float spawnYPosition = GetSpawnYPosition(selectedObstaclePrefab);

                Vector3 spawnPosition = new Vector3(spawnXPosition, spawnYPosition, 0);
                Instantiate(selectedObstaclePrefab, spawnPosition, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }


    private List<GameObject> GetAvailableObstacles(float distance)
    {
        List<GameObject> availableObstacles = new List<GameObject>();

        if (distance < 500f)
        {
            availableObstacles.AddRange(groundObstacles);
        }
        else if (distance >= 500f && distance < 1000f)
        {
            availableObstacles.AddRange(groundObstacles);
            availableObstacles.AddRange(crouchObstacles);
        }
        else if (distance >= 1000f && distance < 1500f)
        {
            availableObstacles.AddRange(groundObstacles);
            availableObstacles.AddRange(benchObstacles);
            availableObstacles.AddRange(crouchObstacles);
        }
        else if (distance >= 1500f && distance < 2000f)
        {
            availableObstacles.AddRange(groundObstacles);
            availableObstacles.AddRange(airObstacles);
            availableObstacles.AddRange(crouchObstacles);
            availableObstacles.AddRange(benchObstacles);
        }

        return availableObstacles;
    }

    private float GetSpawnYPosition(GameObject obstacle)
    {
        if (groundObstacles.Contains(obstacle))
        {
            return groundYPosition;
        }
        else if (airObstacles.Contains(obstacle))
        {
            return Random.Range(minAirYPosition, maxAirYPosition);
        }
        else if (crouchObstacles.Contains(obstacle) || benchObstacles.Contains(obstacle))
        {
            return crouchYPosition;
        }

        return groundYPosition;
    }
}
