using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dusmanScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 1f;
    public float soldierSpeed = 5f;

    private Transform playerTransform;
    private float timer = 0f;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnSoldier();
        }
    }

    void SpawnSoldier()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0f, 1f, 0f);
        spawnPosition.y = playerTransform.position.y;
        GameObject soldier = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        EnemyController EnemyController = soldier.GetComponent<EnemyController>();
        EnemyController.target = playerTransform;
        EnemyController.speed = soldierSpeed;
    }
}

