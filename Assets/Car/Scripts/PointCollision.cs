using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollision : MonoBehaviour
{

    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Point A Car")
        {
            Col.gameObject.SetActive(false);
            Debug.Log("You reached Point A.");
        }

        if (Col.gameObject.tag == "Point B Car")
        {
            Col.gameObject.SetActive(false);
            Debug.Log("You reached Point B.");
        }
    }  
}
