using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class kaleCani : MonoBehaviour
{
    public TMP_Text sayac;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Kale1"))
        {
            sayac.text = (int.Parse(sayac.text) - 1).ToString();

        }
        if (int.Parse(sayac.text)<=0)
        {
            Destroy(other.gameObject);
        }
    }

}
