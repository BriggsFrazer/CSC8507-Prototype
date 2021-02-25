using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 3.0f;
    public float gravity = 9.8f;
    public Camera cam;
    public float speedLimit = 50.0f;
    public bool isGrounded = false;
    public float playerHeight = 0.17f;
    public float jumpPower = 2500;

    public int playerTeam;

    public bool canDropOff;

    public GameObject heldItem;

    public bool selected;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (playerTeam == 0)
        {
            this.transform.Find("Head1").GetComponent<SkinnedMeshRenderer>().material.color = Color.blue;
        }
        else if(playerTeam == 1)
        {
            this.transform.Find("Head1").GetComponent<SkinnedMeshRenderer>().material.color = Color.red;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (selected)
        {
            GroundRaycast();
            Move();
        }

        
    }

    void Move()
    {
        //Camera orientation 
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;
        forward.y = 0.0f;
        right.y = 0.0f;
        forward.Normalize();
        right.Normalize();


        //Character movement controls 
        if (Input.GetKey("w"))
        {
            rb.AddForce(forward * speed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(right * speed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-right * speed * Time.deltaTime);
        }
        if (Input.GetKey("s") )
        {
            rb.AddForce(-forward * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown("space") && isGrounded == true)
        {

            Jump();
        }

        if (Input.GetKey("f"))
        {
            if (GetComponent<AudioSource>())
            {
                Debug.Log("Playing sound");
            }
            GetComponent<AudioSource>().Play();
            if (heldItem)
            {
                GetComponent<AudioSource>().Play();
                Vector3 playerPos = gameObject.transform.position + new Vector3(0,playerHeight,0);
                Vector3 playerDirection = gameObject.transform.forward * 2;
                Quaternion playerRotation = gameObject.transform.rotation;
                float spawnDistance = 0.2f;
                Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
                Instantiate(heldItem, spawnPos, playerRotation);
                heldItem = null;
            }

        }

        float tempY = rb.velocity.y;
        if (rb.velocity.magnitude > speedLimit)
        {
            rb.velocity = rb.velocity.normalized * speedLimit;
        }
        rb.velocity = new Vector3(rb.velocity.x, tempY, rb.velocity.z);

        
        if (rb.velocity.magnitude > 0.02 && (rb.velocity.x != 0 || rb.velocity.z !=0))
        {
            MovementRotation();
        }

    }

    void Jump() {
        isGrounded = false;
        rb.AddForce(transform.up * jumpPower);
        
    }

    void MovementRotation()
    {

        Quaternion movementDirection = Quaternion.LookRotation(rb.velocity);

        movementDirection.x = 0.0f;
        movementDirection.z = 0.0f;
       
        transform.rotation = Quaternion.Slerp(transform.rotation,movementDirection , 0.05F);

    }
   
    void GroundRaycast()
    {
        RaycastHit hitGround;
        if (Physics.Raycast(transform.position, Vector3.down, out hitGround, playerHeight/4))
        {
            if (hitGround.collider.tag == "ground")
            {
                isGrounded = true;
            }
            else {
                isGrounded = false;
            }
        }




    }

    
}
