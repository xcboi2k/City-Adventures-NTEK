using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCarScript : MonoBehaviour
{
    public GameObject[] cars;

    int ram = 0;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn(){
        for (int i=0; i<transform.childCount; i++){
            ram = Random.Range(0,cars.Length);
            Instantiate(cars[ram], transform.GetChild(i).transform.position, transform.GetChild(i).transform.rotation);
        }
    }
}
