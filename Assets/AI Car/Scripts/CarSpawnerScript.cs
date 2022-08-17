using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerScript : MonoBehaviour
{
    public GameObject[] carPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(SelectCarPrefab(), transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject SelectCarPrefab(){
        var randomIndex = Random.Range(0, carPrefabs.Length);
        return carPrefabs[randomIndex];
    }
}
