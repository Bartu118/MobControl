using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform playerTransform;
    public float enemySpeed = 5f;
    public float spawnDistance = 10f;
    public float spawnInterval = 4f;
    public float spawnDuration = 3f;

    private bool isSpawning = false;

    void Start()
    {
        // Start spawning soldiers
        StartCoroutine(SpawnSoldiers());
    }

    IEnumerator SpawnSoldiers()
    {
        while (true)
        {
            // Wait for the spawn interval
            yield return new WaitForSeconds(spawnInterval);

            // Start spawning soldiers for the duration
            isSpawning = true;
            yield return new WaitForSeconds(spawnDuration);
            isSpawning = false;
        }
    }

    void Update()
    {
        if (isSpawning)
        {
            // Spawn a soldier
            SpawnSoldier();
        }
    }

    void SpawnSoldier()
    {
        // Calculate the spawn position for the soldier
        //Vector3 spawnPosition = transform.position + transform.forward * spawnDistance;
        //spawnPosition.y = playerTransform.position.y;

        Vector3 spawnPosition = transform.position + new Vector3(0f, 2f, 0f);
        spawnPosition.y = playerTransform.position.y;

        // Instantiate the soldier and set its target and speed
        GameObject soldierObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        EnemyController EnemyController = soldierObject.GetComponent<EnemyController>();
        EnemyController.target = playerTransform;
        EnemyController.speed = enemySpeed;
    }
}
