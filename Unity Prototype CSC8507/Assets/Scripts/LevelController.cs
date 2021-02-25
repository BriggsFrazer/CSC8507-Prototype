using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    // Start is called before the first frame update
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    // Update is called once per frame
    public void Level2()
    {
        SceneManager.LoadScene("LevelMeteor");
    }

    public void Level3()
    {
        SceneManager.LoadScene("LevelLava");
    }

    public void LevelTest()
    {
        SceneManager.LoadScene("Level_Test");
    }
}
