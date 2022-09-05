using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortPathScript : MonoBehaviour
{
    void OnDrawGizmos()
    {
        int pathId = 1;
        foreach (Transform path in transform)
        {
            if (path.name != "Path-" + pathId.ToString())
                path.name = "Path-" + pathId.ToString();

            pathId++;
        }
    }
}
