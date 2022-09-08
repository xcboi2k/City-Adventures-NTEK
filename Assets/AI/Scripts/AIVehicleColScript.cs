using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIVehicleColScript : MonoBehaviour
{
    // private int accidentTimer = 0;
    // private bool accidentHappen;
    // private bool removeAccident;
    private void Start() {
        // accidentHappen = false;
        // removeAccident = false;
    }

    // private void Update() {
    //     if(accidentHappen == true){
    //         accidentTimer = 3;
    //     }

    //     accidentTimer -= 1;
    //     if(accidentTimer < 0){
    //         removeAccident = true;
    //     }
    // }

    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Gib"){
        Destroy(Col.gameObject);
        Destroy(gameObject);
        Debug.Log("AI Vehicle Accident.");
        }

        if (Col.gameObject.tag == "Unit"){
            Destroy(Col.gameObject);
            Destroy(gameObject);
            Debug.Log("AI Vehicle killed Pedestrian.");
        }

        if(Col.gameObject.tag == "Sidewalk"){
            Destroy(gameObject);
            Debug.Log("AI Vehicle out of bounds.");
        }
    } 
}
