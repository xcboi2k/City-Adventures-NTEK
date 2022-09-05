using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortWayScript : MonoBehaviour
{
    void OnDrawGizmos()
    {
        int wayId = 1;
        foreach (Transform way in transform)
        {
            if (way.name != "Way-" + wayId.ToString())
                way.name = "Way-" + wayId.ToString();

            wayId++;
        }
    }
}
