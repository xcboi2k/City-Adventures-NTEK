using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColScript : MonoBehaviour
{
    public int score;

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

        if(Col.gameObject.tag == "Coin")
        {
            score += 1;
            Debug.Log("Coin added to score.");
        }

        if(Col.gameObject.tag == "Road")
        {
            score -= 1;
            Debug.Log("Go back to Sidewalk!");
        }

        if(Col.gameObject.tag == "Gib")
        {
            score = 0;
            Destroy(Col.gameObject);
            Destroy(gameObject);
            Debug.Log("You were hit by a car.");
        }
    }  
}
