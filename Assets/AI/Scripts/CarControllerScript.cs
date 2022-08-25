using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarControllerScript : MonoBehaviour
{
    Rigidbody rb;

    public float power = 5;
    public float torque = 0.5f;
    public float maxSpeed = 5;

    public Vector2 movementVector;


    void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 movementInput){
        this.movementVector = movementInput;
    }
    
    private void FixedUpdate() {
        if(rb.velocity.magnitude < maxSpeed){
            rb.AddForce(movementVector.y * transform.forward * power);
        }
        rb.AddTorque(movementVector.x * Vector3.up * torque * movementVector.y);
    }
}
