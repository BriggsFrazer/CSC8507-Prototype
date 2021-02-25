using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBetween : MonoBehaviour
{
        public Vector3 startPos;
        public Vector3 endPos;
        public Vector3 currentPos;
        public Rigidbody rb;
        public Vector3 target;    

        public float speed;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            
        }

    private void FixedUpdate()
    {
        if (rb.position == startPos)
        {
            target = endPos;
        }
        else if (rb.position == endPos)
        {
            target = startPos;
        }

        Vector3 newPos = Vector3.MoveTowards(rb.position, target, speed * Time.deltaTime);
        rb.MovePosition(newPos);
    }


}
