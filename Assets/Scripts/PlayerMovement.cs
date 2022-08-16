//using System.Reflection.Metadata;
//using Microsoft.CSharp.RuntimeBinder;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Rigidbody rb;
    public Animator animator;
    [SerializeField] float movementSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
       // rb = GetComponent<Rigidbody>();
       animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * (movementSpeed * Time.deltaTime));
        //rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetKey ("w"))
        {
            animator.SetBool("isWalkingForward", true);
            
            if (Input.GetKey ("d"))
            {
                animator.SetBool("isWalkingForwardRight", true);
            }
            if (!Input.GetKey ("d"))
            {
                animator.SetBool("isWalkingForwardRight", false);
            }
            if (Input.GetKey ("a"))
            {
                animator.SetBool("isWalkingForwardLeft", true);
            }
            if (!Input.GetKey ("a"))
            {
                animator.SetBool("isWalkingForwardLeft", false);
            }
        
        }
        if (!Input.GetKey ("w"))
        {
            animator.SetBool("isWalkingForward", false);
        }

        // Backward
        if (Input.GetKey ("s"))
        {
            animator.SetBool("isWalkingBackward", true);

            if (Input.GetKey ("d"))
            {
                animator.SetBool("isWalkingBackwardRight", true);
            }
            if (!Input.GetKey ("d"))
            {
                animator.SetBool("isWalkingBackwardRight", false);
            }
            if (Input.GetKey ("a"))
            {
                animator.SetBool("isWalkingBackwardLeft", true);
            }
            if (!Input.GetKey ("a"))
            {
                animator.SetBool("isWalkingBackwardLeft", false);
            }
        }
        if (!Input.GetKey ("s"))
        {
            animator.SetBool("isWalkingBackward", false);
        }

        if (Input.GetKey ("a"))
        {
            animator.SetBool("isWalkingLeft", true);

            if (Input.GetKey ("w"))
            {
                animator.SetBool("isWalkingForwardLeft", true);
            }
            if (!Input.GetKey ("w"))
            {
                animator.SetBool("isWalkingForwardLeft", false);
            }
            if (Input.GetKey ("s"))
            {
                animator.SetBool("isWalkingBackwardLeft", true);
            }
            if (!Input.GetKey ("s"))
            {
                animator.SetBool("isWalkingBackwardLeft", false);
            }
        }
        if (!Input.GetKey ("a"))
        {
            animator.SetBool("isWalkingLeft", false);
        }

        if (Input.GetKey ("d"))
        {
            animator.SetBool("isWalkingRight", true);

            if (Input.GetKey ("w"))
            {
                animator.SetBool("isWalkingForwardRight", true);
            }
            if (!Input.GetKey ("w"))
            {
                animator.SetBool("isWalkingForwardRight", false);
            }
            if (Input.GetKey ("s"))
            {
                animator.SetBool("isWalkingBackwardRight", true);
            }
            if (!Input.GetKey ("s"))
            {
                animator.SetBool("isWalkingBackwardRight", false);
            }
        }
        if (!Input.GetKey ("d"))
        {
            animator.SetBool("isWalkingRight", false);
        }
        
    }

}
