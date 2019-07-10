using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour
{
    public void toStart()
    {
        GameManager.resetGame();
        SceneManager.LoadScene("Menu Intro");
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
