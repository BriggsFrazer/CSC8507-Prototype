using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxScript : MonoBehaviour
{
    public GameObject holding;
    public GameObject object1;
    public GameObject object2;

    private void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        if(Random.Range(0,2) == 0)
        {
            holding = object1;
        }
        else{
            holding = object2;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            if (other.GetComponent<PlayerController>().heldItem)
            {

            }
            else
            {
                other.GetComponent<PlayerController>().heldItem = holding;
                Destroy(this.gameObject);
            }
        }
    }

    private void Update()
    {
        transform.Rotate(10 * Time.deltaTime, 30* Time.deltaTime, 50 * Time.deltaTime);
    }
}
