using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarCameraScript : MonoBehaviour
{
    //public GameObject focus;
    //public float distance = 5f;
    //public float height = 2f;
    //public float dampening = 1f;

    // Update is called once per frame
    //void Update(){
        //transform.position = Vector3.Lerp(transform.position, focus.transform.position + focus.transform.TransformDirection(new Vector3(0f, height, -distance)), dampening * Time.deltaTime);
        //transform.LookAt(focus.transform);
    //}
    public float rotationSpeed;
    //public Transform Target, Player;
    float mouseX, mouseY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CamControl();
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -45f, 80f);

        //transform.LookAt(Target);

        transform.localRotation = Quaternion.Euler(0, mouseX, 0);

        //Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        //Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
