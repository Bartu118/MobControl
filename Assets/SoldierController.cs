using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float stoppingDistance = 1f;
    public GameObject asker;
    private Vector3 targetPosition;

    void Update()
    {
        // Move towards the target position
        Vector3 direction = targetPosition - transform.position;
        if (direction.magnitude > stoppingDistance)
        {
            transform.position += direction.normalized * moveSpeed * Time.deltaTime;
        }
    }

    public void SetTarget(Vector3 target)
    {
        targetPosition = target;
    }
    public GameObject karakter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(karakter);

        }
    }
}