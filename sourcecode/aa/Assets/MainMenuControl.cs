using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    void Start()
    {
        //PlayerPrefs.DeleteAll();
    }
    public void startGame()
    {
        int level = PlayerPrefs.GetInt("saveLevel");
        if (level == 0)
        {
            SceneManager.LoadScene("1");
        }
        else
        {
            SceneManager.LoadScene(level);
        }
        
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
