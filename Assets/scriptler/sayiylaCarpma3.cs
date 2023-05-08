using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sayiylaCarpma3 : MonoBehaviour
{
    private GameObject targetObject;
    void Start()
    {
        targetObject = GameObject.FindGameObjectWithTag("Kale1");
        if (targetObject == null)
        {
            targetObject = GameObject.FindGameObjectWithTag("Kale2");
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CloneTrigger3"))
        {
            // Specify the number of times to clone the soldier
            int numberOfClones = 2;

            // Clone the soldier
            for (int i = 0; i < numberOfClones; i++)
            {
                float offset = 1.5f * (i + 1);
                Vector3 spawnPosition = transform.position + new Vector3(offset, 0f, 0f);
                Quaternion spawnRotation = transform.rotation;

                GameObject newSoldier = Instantiate(gameObject, spawnPosition, spawnRotation);

                // Update the target of the cloned soldier
                SoldierController soldierController = newSoldier.GetComponent<SoldierController>();
                if (soldierController != null)
                {

                    soldierController.SetTarget(targetObject.transform.position);
                }
            }
        }
    }
}
