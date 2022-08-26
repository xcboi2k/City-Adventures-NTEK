using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAIScript : MonoBehaviour
{
    public float safeDistance = 3f;
    public float carSpeed = 5f;

    public GameObject currentTrafficRoute;
    public GameObject nextWaypoint;
    public int currentWaypointNumber;

    private NavMeshAgent carNavMesh;
    // Start is called before the first frame update
    void Start()
    {
        carNavMesh = this.gameObject.GetComponent<NavMeshAgent>();
        carNavMesh.speed = carSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, safeDistance);

        if(hit.transform){
            if(hit.transform.tag == "Car"){
                Stop();
            }
        }
        else{
            Move();
        }
    }

    void Move(){
        if(nextWaypoint == null){
            carNavMesh.speed = 0;
        }
        else{
            carNavMesh.speed = carSpeed;
        }
        if(currentWaypointNumber > 0){
            if(carNavMesh.speed == 0){
                carNavMesh.speed = carSpeed;
            }
            carNavMesh.SetDestination(currentTrafficRoute.transform.GetChild(currentWaypointNumber - 1).transform.position);
        }
        else{
            if(carNavMesh.speed == 0){
                carNavMesh.speed = carSpeed;
            }
            if(nextWaypoint != null){
                carNavMesh.SetDestination(nextWaypoint.transform.position);
            }
        }
        if(currentWaypointNumber > 0){
            float distance = Vector3.Distance(transform.position, currentTrafficRoute.transform.GetChild(currentWaypointNumber - 1).transform.position);
            if(distance <= 1){
                currentWaypointNumber -= 1;
            }
        }
        else{
            float distance = Vector3.Distance(transform.position, nextWaypoint.transform.position);
            if(distance <= 1){
                currentWaypointNumber = 4;
                currentTrafficRoute = nextWaypoint.transform.parent.gameObject;
            }
        }
    }

    void Stop(){
        carNavMesh.speed = 0;;
    }
}
