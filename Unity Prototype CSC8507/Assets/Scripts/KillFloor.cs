using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    public Vector3 spawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            other.transform.position = spawnPoint;
            foreach(var cube in other.GetComponent<PickUpScript>().stack)
            {
                Destroy(cube);
            }
            other.GetComponent<PickUpScript>().stack.Clear();
        }
        else
        {
            Debug.Log("Detected collision");
            Destroy(other.gameObject);
        }
    }
}
