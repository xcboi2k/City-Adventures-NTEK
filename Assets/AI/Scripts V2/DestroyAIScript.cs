using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAIScript : MonoBehaviour
{
    public float clearDistance = 150.0f;
    public GameObject myRoot;
    public Renderer myBody;

    public bool human, vehicle;
    void Update()
    {
        //Destroy(myRoot);
        Lean.Pool.LeanPool.Despawn(myRoot);
        if (human) AIControllerScript.manager.currentHumans--;
        if (vehicle) AIControllerScript.manager.currentVehicles--;
    }
}
