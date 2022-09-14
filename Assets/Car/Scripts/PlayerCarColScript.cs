using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarColScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision Col) {
        if (Col.gameObject.tag == "Gib"){
            Debug.Log("Look at other vehicles.");
        }

        if (Col.gameObject.tag == "Unit"){
            Debug.Log("Watch out on pedestrians.");
        }
    }

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
            Debug.Log("Why are you on the sidewalk?");
        }

        if(Col.gameObject.tag == "Cross"){
            Debug.Log("Peds crossing.");
        }
    }  
}
