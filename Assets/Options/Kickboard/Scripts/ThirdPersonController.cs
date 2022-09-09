using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public float speed;
    Animator animator;

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        if (Input.GetKey ("w"))
        {
            animator.SetBool("isForward", true);
        }
        if (!Input.GetKey ("w"))
        {
            animator.SetBool("isForward", false);
        }
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMove = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;
        transform.Translate(playerMove, Space.Self);
    }
}
