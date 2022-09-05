using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAIScript : MonoBehaviour
{
    public LayerMask nodeMask = -1;
    public float InstantiateTime = 2.0f;

    private float vehicleTimer, humanTimer;

    public bool createVehicles = true;
    public bool createHumans = true;

    private AIControllerScript AICScript;
    private GameObject AiVehicleCreated;
    private GameObject AIVehicle;
    private float offsetDistance = 25;
    private int randomWay;



    public void InstantiateVehicle(NodeScript CurrentNode)
    {

        Collider[] vehicles = Physics.OverlapSphere(CurrentNode.transform.position, offsetDistance);

        bool CanCreateVehicle = true;

        foreach (Collider vehicle in vehicles)
        {
            if (vehicle.CompareTag("Vehicle"))
                CanCreateVehicle = false;
        }


        AIVehicle = AIControllerScript.manager.vehiclesPrefabs[Random.Range(0, AIControllerScript.manager.vehiclesPrefabs.Length)];

        if (AIVehicle)
        {
            if (CanCreateVehicle && AIControllerScript.manager.currentVehicles < AIControllerScript.manager.maxVehicles)
            {
                RaycastHit hit;
                if (Physics.Raycast(CurrentNode.transform.position, -Vector3.up, out hit))
                {
                    AIControllerScript.manager.currentVehicles++;
                    AiVehicleCreated = Instantiate(AIVehicle, hit.point + (Vector3.up / 2.0f), Quaternion.identity) as GameObject;
                    // AiVehicleCreated = Lean.Pool.LeanPool.Spawn(AIVehicle, hit.point + (Vector3.up / 2.0f), Quaternion.identity) as GameObject;
                    Debug.Log("A car has spawned.");
                }
                AiVehicleCreated.name = "AIVehicle";

                if (AiVehicleCreated.GetComponent<AIVehicleScript>())
                {

                    AIVehicleScript AIVScript = AiVehicleCreated.GetComponent<AIVehicleScript>();

                    if (CurrentNode.mode == "TwoWay")
                    {
                        randomWay = Random.Range(1, 3);

                        if (randomWay == 1)
                        {
                            AIVScript.wayMove = WayMove.Left;
                            AIVScript.myStatue = "NextPoint";
                            AiVehicleCreated.transform.LookAt(CurrentNode.previousNode);
                            AIVScript.currentNode = CurrentNode.transform;
                            AIVScript.nextNode = CurrentNode.nextNode;

                            AiVehicleCreated.transform.position = AiVehicleCreated.transform.TransformPoint(CurrentNode.widthDistance, 0, 0);


                        }
                        else
                        {
                            AIVScript.wayMove = WayMove.Right;
                            AIVScript.myStatue = "PreviousPoint";
                            AiVehicleCreated.transform.LookAt(CurrentNode.nextNode);
                            AIVScript.currentNode = CurrentNode.transform;
                            AIVScript.nextNode = CurrentNode.previousNode;

                            AiVehicleCreated.transform.position = AiVehicleCreated.transform.TransformPoint(CurrentNode.widthDistance, 0, 0);

                        }
                    }
                    else
                    {

                        AIVScript.wayMove = WayMove.Right;
                        AIVScript.myStatue = "PreviousPoint";
                        AiVehicleCreated.transform.LookAt(CurrentNode.nextNode);
                        AIVScript.currentNode = CurrentNode.transform;
                        AIVScript.nextNode = CurrentNode.nextNode;

                        AiVehicleCreated.transform.position = AiVehicleCreated.transform.TransformPoint(Random.Range(-CurrentNode.widthDistance, CurrentNode.widthDistance) / 2.0f, 0, 0);

                    }
                }

            }


        }
    }


    void CeateAIHuman(GameObject AIHuman)
    {
        Vector3 randomDirection = Random.insideUnitSphere * 200;
        randomDirection += transform.position;
        UnityEngine.AI.NavMeshHit closestHit;

        if (UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out closestHit, 200f, UnityEngine.AI.NavMesh.AllAreas))
        {
            Collider[] Colliders = Physics.OverlapSphere(closestHit.position, 25.0f);
            bool CreateHuman = true;

            foreach (Collider collider in Colliders)
                if (collider.tag == "Human" || collider.tag == "Vehicle") CreateHuman = false;

            if (CreateHuman && AIControllerScript.manager.currentHumans < AIControllerScript.manager.maxHumans)
            {
                AIControllerScript.manager.currentHumans++;
                Instantiate(AIHuman, closestHit.position, Quaternion.identity);
            }
        }
    }



    void Awake()
    {
        AICScript = AIControllerScript.manager;
    }



    void Update()
    {


        if (createHumans)
        {
            if (AIControllerScript.manager.humansPrefabs.Length > 0)
            {
                if (humanTimer == 0)
                {
                    CeateAIHuman(AIControllerScript.manager.humansPrefabs[Random.Range(0, AIControllerScript.manager.humansPrefabs.Length)]);
                    humanTimer = InstantiateTime;
                }
                else
                {
                    humanTimer = Mathf.MoveTowards(humanTimer, 0.0f, Time.deltaTime);
                }
            }
        }



        if (createVehicles)
        {
            if (vehicleTimer == 0)
            {
                Collider[] nodes = Physics.OverlapSphere(transform.position, 300, nodeMask);
                    foreach (Collider node in nodes)
                    {
                    float Dist = Vector3.Distance(transform.position, node.transform.position);

                        if (Dist < 250 && Dist > 200)
                        {
                            if (node.GetComponent<NodeScript>() && AIControllerScript.manager.vehiclesPrefabs.Length > 0)
                            {
                                if (!GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(Camera.main), node.bounds))
                                {
                                    InstantiateVehicle(node.GetComponent<NodeScript>());
                                    vehicleTimer = InstantiateTime;

                                }


                            }

                        }
                    }
                
            }
            else
            {
                vehicleTimer = Mathf.MoveTowards(vehicleTimer, 0.0f, Time.deltaTime);
            }
        }
    }
}
