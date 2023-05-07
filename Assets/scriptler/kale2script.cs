using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kale2script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Kale1") == null)
        {
            gameObject.SetActive(true);
        }
    }
}
