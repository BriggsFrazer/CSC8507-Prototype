using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldItemScript : MonoBehaviour
{
    public GameObject gameInfo;

    // Update is called once per frame
    void Update()
    {
        if (gameInfo.GetComponent<GameInfoScript>().currentPlayer.GetComponent<PlayerController>().heldItem)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Held Item: " + gameInfo.GetComponent<GameInfoScript>().currentPlayer.GetComponent<PlayerController>().heldItem.name;
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "No item!";
        }
    }
}
