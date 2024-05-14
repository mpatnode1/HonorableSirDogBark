using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public void LoadTutorial()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");

    }

}
