using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision Col) {
        if (Col.gameObject.tag == "Gib"){
            Debug.Log("Look at incoming vehicles.");
        }
    }

    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "PlayerPointA")
        {
            Debug.Log("You reached Point A.");
        }

        if (Col.gameObject.tag == "PlayerPointB")
        {
            Debug.Log("You reached Point B.");
        }

        if(Col.gameObject.tag == "Coin"){
            Debug.Log("Coin added to score.");
        }

        if(Col.gameObject.tag == "Road"){
            Debug.Log("Why are you on the road?");
        }

        if(Col.gameObject.tag == "NoCross"){
            Debug.Log("No Jaywalking");
        }
    }  
}
