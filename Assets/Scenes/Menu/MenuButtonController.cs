using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour
{
    public void toStart()
    {
        SceneManager.LoadScene("Menu Intro");
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
