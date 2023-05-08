using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kale2script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("Kale1") == null)
        {
            gameObject.SetActive(true);
        }
        if(GameObject.FindWithTag("Kale2")==null)
        {
            
        }
    }
}
