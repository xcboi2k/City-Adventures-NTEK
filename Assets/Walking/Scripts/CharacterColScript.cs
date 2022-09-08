using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColScript : MonoBehaviour
{
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
    }  
}
