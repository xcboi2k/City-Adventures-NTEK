using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int score = 0;

    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Coin")
        {
            score = score + 1;
            Col.gameObject.SetActive(false);
            Debug.Log("You earned a point.");

            //Destroy(gameObject);
        }
    }
}
