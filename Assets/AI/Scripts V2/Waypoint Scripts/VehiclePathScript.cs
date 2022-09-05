using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiclePathScript : MonoBehaviour
{
    public Color pathColor = new Color(1, 0.5f, 0);

    private NodeScript nodeComponent;
    private Transform firstNode;

    void Start()
    {
        int nodeId = 0;
        foreach (Transform node in transform)
        {
            if (nodeId == 0)
            {
                firstNode = node;
                nodeId++;
            }
            node.GetComponent<NodeScript>().mode = firstNode.GetComponent<NodeScript>().mode;
        }
    }

    void OnDrawGizmos()
    {
        int nodeId = 1;
        Gizmos.color = pathColor;

        foreach (Transform node in transform)
        {
            nodeComponent = node.GetComponent<NodeScript>();

            if (nodeId == 1)
            {
                nodeComponent.firistNode = true;
                nodeComponent.lastNode = false;
            }
            else if (nodeId == transform.childCount)
            {
                nodeComponent.firistNode = false;
                nodeComponent.lastNode = true;
            }
            else
            {
                nodeComponent.firistNode = false;
                nodeComponent.lastNode = false;
            }


            if (!nodeComponent)
            {
                node.gameObject.AddComponent<NodeScript>();
                nodeComponent.nodeColor = pathColor;
                nodeComponent.parentPath = this.name;
            }
            else
            {
                nodeComponent.nodeColor = pathColor;
                nodeComponent.parentPath = this.name;
            }

            if (node.name != nodeId.ToString())
                node.name = nodeId.ToString();

            nodeId++;

            Transform nextNode = transform.Find(nodeId.ToString());
            Transform beforeNode = transform.Find((nodeId - 2).ToString());

            if (beforeNode)
                nodeComponent.previousNode = beforeNode;

            if (nextNode)
            {
                Gizmos.DrawLine(node.position, nextNode.position);
                nodeComponent.nextNode = nextNode;
            }
        }
    }
}
