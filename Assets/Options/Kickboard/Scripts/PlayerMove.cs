using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Animator animator;
    [SerializeField] float movementSpeed = 5f;
    public float rotationSpeed;
    public float camSpeed;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        LookAtmouse();

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
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
            animator.SetBool("isForward", true);
        }
        if (!Input.GetKey ("w"))
        {
            animator.SetBool("isForward", false);
        }
        if (Input.GetKey ("a"))
        {
            animator.SetBool("isLeft", true);
        }
        if (!Input.GetKey ("a"))
        {
            animator.SetBool("isLeft", false);
        }
        if (Input.GetKey ("d"))
        {
            animator.SetBool("isRight", true);
        }
        if (!Input.GetKey ("d"))
        {
            animator.SetBool("isRight", false);
        }
        if (Input.GetKey ("s"))
        {
            animator.SetBool("isBackward", true);
        }
        if (!Input.GetKey ("s"))
        {
            animator.SetBool("isBackward", false);
        }
    }

    void LookAtmouse()
    {
        Plane playerplane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist;

        if(playerplane.Raycast(ray, out hitdist))
        {
            Vector3 targetpoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetpoint-transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, camSpeed * Time.deltaTime);
        }
    }
}
