using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPedColScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider Col)
    {

        if(Col.gameObject.tag == "Road"){
            Destroy(this.gameObject);
            Debug.Log("No jaywalking.");
        }
    }  
}
