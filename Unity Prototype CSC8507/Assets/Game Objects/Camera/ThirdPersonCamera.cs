using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Adapted from https://gamedevacademy.org/unity-3d-first-and-third-person-view-tutorial/

public class ThirdPersonCamera: MonoBehaviour
{
    public float turnSpeed = 4.0f;
    public GameObject target;
    private float targetDistance;
    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 0.0f;
    private float rotX;

    // Start is called before the first frame update
    void Start()
    {
        targetDistance = Vector3.Distance(transform.position, target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;

        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);

        transform.position = target.transform.position - (transform.forward * targetDistance);
    }
}
