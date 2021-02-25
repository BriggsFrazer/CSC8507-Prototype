using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoScript : MonoBehaviour
{
    public GameObject currentPlayer;

    public GameObject shell;

    public GameObject itemBox;

    public int ScoreLimit;

    public bool Winner;



    private void Start()
    {

        GameObject.Find("GameInfoHolder").GetComponent<GameInfoScript>().currentPlayer = GameObject.Find("Player1");
        GameObject.Find("Camera").GetComponent<ThirdPersonCamera>().target = GameObject.Find("Player1");
        GameObject.Find("GameInfoHolder").GetComponent<GameInfoScript>().currentPlayer.GetComponent<PlayerController>().selected = true;

        GameObject.Find("UserUI").transform.Find("WinScreen").gameObject.SetActive(false);

        
    }
    private void Update()
    {


        if (Input.GetKeyDown("1"))
        {
            GameObject.Find("GameInfoHolder").GetComponent<GameInfoScript>().currentPlayer.GetComponent<PlayerController>().selected = false;
            GameObject.Find("GameInfoHolder").GetComponent<GameInfoScript>().currentPlayer = GameObject.Find("Player1");
            GameObject.Find("Camera").GetComponent<ThirdPersonCamera>().target = GameObject.Find("Player1");
            GameObject.Find("GameInfoHolder").GetComponent<GameInfoScript>().currentPlayer.GetComponent<PlayerController>().selected = true;

        }
        else if (Input.GetKeyDown("2"))
        {
            GameObject.Find("GameInfoHolder").GetComponent<GameInfoScript>().currentPlayer.GetComponent<PlayerController>().selected = false;
            GameObject.Find("GameInfoHolder").GetComponent<GameInfoScript>().currentPlayer = GameObject.Find("Player2");
            GameObject.Find("Camera").GetComponent<ThirdPersonCamera>().target = GameObject.Find("Player2");
            GameObject.Find("GameInfoHolder").GetComponent<GameInfoScript>().currentPlayer.GetComponent<PlayerController>().selected = true;
        }

        if(GameObject.Find("RedTeamDropOff").GetComponent<TeamController>().score >= ScoreLimit)
        {
            GameObject.Find("UserUI").transform.Find("WinScreen").gameObject.SetActive(true);
            GameObject.Find("UserUI").transform.Find("WinScreen").transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text = "THE WINNER IS \n RED TEAM \n PRESS ESCAPE TO GO BACK";
            Time.timeScale = 0;
        }
        else if (GameObject.Find("BlueTeamDropOff").GetComponent<TeamController>().score >= ScoreLimit)
        {
            GameObject.Find("UserUI").transform.Find("WinScreen").gameObject.SetActive(true);
            GameObject.Find("UserUI").transform.Find("WinScreen").transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text = "THE WINNER IS \n BLUE TEAM \n PRESS ESCAPE TO GO BACK";
            Time.timeScale = 0;
        }

    }
    

}
