using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{

    Animator animator;
    [SerializeField] float movementSpeed = 5f;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        //transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * (movementSpeed * Time.deltaTime));
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * movementSpeed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey ("w"))
        {
            animator.SetBool("isWalkingForward", true);
        }
        if (!Input.GetKey ("w"))
        {
            animator.SetBool("isWalkingForward", false);
        }
        if (Input.GetKey ("a"))
        {
            animator.SetBool("isWalkingLeft", true);
        }
        if (!Input.GetKey ("a"))
        {
            animator.SetBool("isWalkingLeft", false);
        }
        if (Input.GetKey ("d"))
        {
            animator.SetBool("isWalkingRight", true);
        }
        if (!Input.GetKey ("d"))
        {
            animator.SetBool("isWalkingRight", false);
        }
        if (Input.GetKey ("s"))
        {
            animator.SetBool("isWalkingBackward", true);
        }
        if (!Input.GetKey ("s"))
        {
            animator.SetBool("isWalkingBackward", false);
        }
    }
}
