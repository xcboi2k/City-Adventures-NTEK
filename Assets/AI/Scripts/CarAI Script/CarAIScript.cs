using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAIScript : MonoBehaviour
{
    public float safeDistance = 3f;
    public float carSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
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
        transform.position += new Vector3(carSpeed * Time.deltaTime,0,0);
    }

    void Stop(){
        transform.position += new Vector3(0,0,0);
    }
}
