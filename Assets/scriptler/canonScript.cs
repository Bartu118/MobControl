using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonScript : MonoBehaviour
{
    public GameObject soldierPrefab;
    public float moveSpeed = 10f;
    private float spawnInterval = 0.1f;
    private float spawnRadius = 0f;
    private GameObject targetObject;
    public float spawnPointOffset = 0f;

    private Vector3 moveDirection;
    private float spawnTimer;


    public bool kale1Pozisyon = true;
    public bool kale2Pozisyon = true;
    public bool lookAround = true;
    private Vector3 movement;
    [SerializeField] private float speed = 10;

    void Start()
    {
        transform.position = new Vector3(0f, 1f, 0f);
        
    }

    void Update()
    {

        if (lookAround)
        {
            if (GameObject.FindWithTag("Kale1") != null)
            {
                Movement1();
            }

            if (GameObject.FindWithTag("Kale1") == null)
            {
                Movement2();
            }

            // Read mouse input
            float mouseX = Input.GetAxis("Mouse X");

            // Move character
            moveDirection = new Vector3(mouseX, 0, 0);
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            //  bu 2 if kodunu ekledim
            if (GameObject.FindWithTag("Kale1") == null && kale1Pozisyon)
            {
                lookAround = false;
                transform.position = Vector3.MoveTowards(transform.position, GameObject.FindWithTag("kale1Pozisyon").transform.position, 10 * Time.deltaTime);
                if (transform.position == GameObject.FindWithTag("kale1Pozisyon").transform.position)
                {
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    kale1Pozisyon = false;
                    lookAround = true;
                }
                if (GameObject.FindWithTag("Kale2") == null && kale2Pozisyon)
                {
                    lookAround = false;
                    transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Kale2Pozisyon").transform.position, 10 * Time.deltaTime);
                    if (transform.position == GameObject.Find("Kale2Pozisyon").transform.position)
                    {
                        kale2Pozisyon = false;
                        lookAround = true;
                    }
                }

            }


        }
        // Spawn soldiers
        if (Input.GetMouseButton(0))
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                Vector3 spawnPosition = transform.position + moveDirection.normalized * spawnPointOffset;
                bool canSpawn = !Physics.CheckSphere(spawnPosition, spawnRadius);

                // Spawn soldier if there are no nearby soldiers
                if (canSpawn)
                {
                    GameObject newSoldier = Instantiate(soldierPrefab, spawnPosition, Quaternion.identity);
                    targetObject = GameObject.FindGameObjectWithTag("Kale1");
                    if (targetObject == null)
                    {
                        targetObject = GameObject.FindGameObjectWithTag("Kale2");
                    }
                    // Make the soldier move towards the enemy
                    SoldierController soldierController = newSoldier.GetComponent<SoldierController>();
                    if (soldierController != null)
                    {
                        soldierController.SetTarget(targetObject.transform.position);
                    }
                }

                spawnTimer = 0f;
            }
        }
    }
    private void Movement1()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        movement = new Vector3(x, 0f, 0f);
        transform.position += movement;
    }

    private void Movement2()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        movement = new Vector3(0f, 0f, x);
        transform.position += movement;
    }
}
