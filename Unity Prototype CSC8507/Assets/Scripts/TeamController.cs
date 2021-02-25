using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour
{
    public int score;
    public int teamNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() )
        {
            if (other.GetComponent<PlayerController>().playerTeam == teamNumber)
            {
                other.GetComponent<PlayerController>().canDropOff = true;
                other.GetComponent<PickUpScript>().dropOffZone = this.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            other.GetComponent<PlayerController>().canDropOff = false;

        }
    }
}
