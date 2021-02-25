using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{

    public int team;
    public GameObject teamController;

    void Update()
    {
       if(team == 0)
        {
            GetComponent<UnityEngine.UI.Text>().text = "Blue Team: " + teamController.GetComponent<TeamController>().score.ToString();
        }
       else if(team == 1)
        {
            GetComponent<UnityEngine.UI.Text>().text = teamController.GetComponent<TeamController>().score.ToString() + " :Red Team";
        }

        var Amount = (float)teamController.GetComponent<TeamController>().score / (float)GameObject.Find("GameInfoHolder").GetComponent<GameInfoScript>().ScoreLimit;

        this.transform.Find("ScoreFill").GetComponent<UnityEngine.UI.Image>().fillAmount = Amount;
    }
}
