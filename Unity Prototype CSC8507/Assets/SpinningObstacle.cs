using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObstacle : MonoBehaviour
{
    // Start is called before the first frame update


    public Vector3 spin;
    public float speed;
    // Update is called once per frame
    void FixedUpdate()
    {

        this.GetComponent<Rigidbody>().MoveRotation(this.GetComponent<Rigidbody>().rotation * Quaternion.Euler(spin * speed));
    }
}
