using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPathScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PointA")
        {
            other.gameObject.SetActive(false);
            Debug.Log("You are in Point A");
        }
        if(other.gameObject.tag == "PointB")
        {
            other.gameObject.SetActive(false);
            Debug.Log("You are in Point B");
        }
    }

    //IF YOU USE THIS CODE, PUT IT IN POINT A AND POINT B

    //GameObject[] PointA;
    //GameObject[] PointB;


    //private void OnTriggerEnter(Collider other)
    //{
        //if(other.CompareTag("Player"))
        //{
            //PointA = GameObject.FindGameObjectsWithTag("PointA");
            //if(tag == "PointA")
            //{
                //foreach(GameObject a in PointA)
                //{
                    //Destroy(this.gameObject);
                    //Debug.Log("You are in Point A");
                //}
            //}
        //}
        
        //if(other.CompareTag("Player"))
        //{
            //PointB = GameObject.FindGameObjectsWithTag("PointB");
            //if(tag == "PointB")
            //{
                //foreach(GameObject b in PointB)
                //{
                    //Destroy(this.gameObject);
                    //Debug.Log("You are in Point B");
                //}
            //}
        //}
    //}
}
