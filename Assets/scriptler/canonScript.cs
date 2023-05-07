using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonScript : MonoBehaviour
{
    public GameObject soldierPrefab;
    public float moveSpeed = 10f;
    private float spawnInterval = 0.1f;
    private float spawnRadius = 0.01f;
    public GameObject enemy;
    public float spawnPointx;
    public float spawnPointy;
    public float spawnPointz;
    private Vector3 moveDirection;
    private float spawnTimer;

    

    void Start()
    {
        transform.position = new Vector3(0f, 1f, 0f);
    }
    void Update()
    {
        // Read mouse input
        float mouseX = Input.GetAxis("Mouse X");

        // Move character
        moveDirection = new Vector3(mouseX, 0, 0);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;






        // Spawn soldiers
        if (Input.GetMouseButton(0))
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                // Check for nearby soldiers
                Vector3 spawnPosition = transform.position + new Vector3(spawnPointx, spawnPointy, spawnPointz);
                bool canSpawn = !Physics.CheckSphere(spawnPosition, spawnRadius);

                // Spawn soldier if there are no nearby soldiers
                if (canSpawn)
                {
                    GameObject newSoldier = Instantiate(soldierPrefab, spawnPosition, Quaternion.identity);

                    // Make the soldier move towards the enemy
                    SoldierController soldierController = newSoldier.GetComponent<SoldierController>();
                    if (soldierController != null)
                    {
                        soldierController.SetTarget(enemy.transform.position);
                    }
                }

                spawnTimer = 0f;
            }
        }
    }
}
