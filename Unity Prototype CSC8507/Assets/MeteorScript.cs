using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    Rigidbody rb;
    public float force;
    public float radius;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<AudioSource>().Play();

    }
    private void FixedUpdate()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(force, transform.position,radius, 1.0F);
        }
        
        Destroy(gameObject);
    }
}
