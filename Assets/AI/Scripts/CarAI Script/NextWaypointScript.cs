using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWaypointScript : MonoBehaviour
{
    public GameObject[] Waypoints;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Car"){
            if(Waypoints.Length > 0){
                other.gameObject.GetComponent<CarAIScript>().nextWaypoint = null;
            }
            else{
                int ram = Random.Range(0,Waypoints.Length);
                other.gameObject.GetComponent<CarAIScript>().nextWaypoint = Waypoints[ram];
            }
             
        }
    }
}
