using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarColScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "CarPointA")
        {
            Debug.Log("You reached Point A.");
        }

        if (Col.gameObject.tag == "CarPointB")
        {
            Debug.Log("You reached Point B.");
        }

        if(Col.gameObject.tag == "Coin"){
            Debug.Log("Coin added to score.");
        }

        if(Col.gameObject.tag == "Sidewalk"){
            Debug.Log("Don't drive on sidewalks.");
        }

        if(Col.gameObject.tag == "Gib"){
            Debug.Log("You hit a car.");
        }

        if(Col.gameObject.tag == "Unit"){
            Debug.Log("You hit a ped.");
        }
    }  
}
