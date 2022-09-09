using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KickboardMoveScript : MonoBehaviour
{
    CharacterController controller;
    public GameObject body;
    Vector2 MouseMovement()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        return new Vector2(x, y);
    }

    Vector2 KeyboardAxis()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        return new Vector2(x, y);
    }

    public GameObject view;
    public float viewSpeed;
    Vector3 viewRotation;
    void CharacterLook(Vector2 mouseMovement)
    {
        mouseMovement *= viewSpeed * Time.deltaTime;

        viewRotation.x -= mouseMovement.y;
        viewRotation.y += mouseMovement.x;

        viewRotation.x = Mathf.Clamp(viewRotation.x, -90, 90);


        view.transform.rotation = Quaternion.Lerp(view.transform.rotation, Quaternion.Euler(viewRotation), 25f * -Time.deltaTime);
    }

    public bool onTheGround;
    public Vector3 groundNormal;
    void GroundCheck()
    {
        Ray ray = new Ray(controller.transform.position + (Vector3.up), Vector3.down);
        RaycastHit hit;
        int groundLayer = LayerMask.GetMask("Ground");

        onTheGround = Physics.CheckSphere(controller.transform.position + new Vector3(0f, 0.48f, 0f), 0.50f, groundLayer);

        if(Physics.Raycast(ray, out hit, 10f, groundLayer))
        {
            if (onTheGround)
                groundNormal = hit.normal;
            else
                groundNormal = Vector3.up;
        }
    }


    private Vector3 movement;
    private Vector3 movementAdjustment;
    public float walkSpeed = 3f;
    public float runSpeed = 5f;
    private float moveSpeed = 3f;

    void CharacterPosition()
    {
        if (onTheGround)
        {
            if (KeyboardAxis().magnitude != 0)
            {
                movement = (body.transform.right * KeyboardAxis().x + body.transform.forward * KeyboardAxis().y).normalized;
                movement = Vector3.ProjectOnPlane(movement, groundNormal);

            }
            else
            {
                moveSpeed = Mathf.Lerp(moveSpeed, 0f, 4f * Time.deltaTime);
            }
            movementAdjustment.y = 0f;
        }
        else
        {
            movementAdjustment.y -= 20f * Time.deltaTime;
        }

        controller.Move(((movement.normalized * moveSpeed) + movementAdjustment) * Time.deltaTime);
    }


    // Update is called once per frame
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        GroundCheck();
        CharacterPosition();
        CharacterLook(MouseMovement());
    }
}

