using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinWalk : MonoBehaviour
{
    public int score = 0;

    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Coins")
        {
            score = score + 1;
            Col.gameObject.SetActive(false);
            Debug.Log("You earned a point.");
        }
    }
}
